using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Diagrams
{
    public class DiagramsUnitOfWork : UnitOfWork
    {
        public DbContext Context { get; }

        public DiagramsUnitOfWork(Func<DbContext> dbContextFactory)
        {
            if (dbContextFactory == null)
            {
                throw new ArgumentNullException(nameof(dbContextFactory));
            }
            Context = dbContextFactory.Invoke();
        }

        public override async Task CommitCore()
        {
            await Context.SaveChangesAsync();
        }

        public override void Dispose()
        {
            Context.Dispose();
        }
    }
}
