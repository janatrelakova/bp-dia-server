using Infrastructure.UoW;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Diagrams
{
    public class DiagramsUnitOfWorkProvider : UnitOfWorkProvider
    {
        private readonly Func<DbContext> _dbContextFactory;

        public DiagramsUnitOfWorkProvider(Func<DbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
        }

        public override IUnitOfWork Create()
        {
            uowInstance.Value = new DiagramsUnitOfWork(_dbContextFactory);
            return uowInstance.Value;
        }

    }
}
