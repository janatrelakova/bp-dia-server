using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        /// <summary>
        /// Gets the entity with given id.
        /// </summary>
        Task<TEntity> GetAsync(Guid id);

        /// <summary>
        /// Creates the given entity.
        /// </summary>
        Task CreateAsync(TEntity entity);

        /// <summary>
        /// Updates the given entity.
        /// </summary>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Deletes an entity with the given id.
        /// </summary>
        Task DeleteAsync(Guid id);

    }
}
