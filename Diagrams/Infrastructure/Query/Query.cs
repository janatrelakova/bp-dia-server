using Infrastructure.Diagrams;
using Infrastructure.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Query
{
    public class Query<TEntity> : IQuery<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly IUnitOfWorkProvider _provider;
        private readonly ILogger<IQuery<TEntity>> _logger;
        protected DbContext Context => ((DiagramsUnitOfWork)_provider.GetUOWInstance()).Context;

        public Query(IUnitOfWorkProvider provider, ILogger<IQuery<TEntity>> logger)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<TEntity>> GetSetAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

    }
}
