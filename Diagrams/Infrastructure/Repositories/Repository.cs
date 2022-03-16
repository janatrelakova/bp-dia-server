using Infrastructure.Diagrams;
using Infrastructure.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Entities;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntity, new()
    {

        private readonly IUnitOfWorkProvider _provider;
        private readonly ILogger<IRepository<T>> _logger;

        protected DbContext Context { get => ((DiagramsUnitOfWork)_provider.GetUOWInstance()).Context; }

        public Repository(IUnitOfWorkProvider provider, ILogger<IRepository<T>> logger)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task CreateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), $"Given entity was null.");
            }
            entity.Id = Guid.NewGuid();
            await Context.Set<T>().AddAsync(entity);
            _logger.LogInformation($"Entity with {entity.Id} has been successfully created.");
        }

        public async Task DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id), $"Given ID was empty Guid.");
            }

            var entity = await Context.Set<T>().FindAsync(id);

            if (entity == null)
            {
                _logger.LogWarning($"Entity with ID {id} has not been found.");
                return;
            }
            Context.Set<T>().Remove(entity);
        }

        public async Task<T> GetAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id), $"Given ID was empty Guid.");
            }

            return await Context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null) 
            {
                throw new ArgumentNullException(nameof(entity), $"Given entity was null.");
            }

            var foundEntity = await GetAsync(entity.Id);
            Context.Entry(foundEntity).CurrentValues.SetValues(entity);
        }
    }
}
