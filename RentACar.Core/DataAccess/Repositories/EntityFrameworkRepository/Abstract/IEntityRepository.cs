using RentACar.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.DataAccess.Repositories.EntityFrameworkRepository.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {

        /// <summary>
        /// Retrieves all entities that match the specified filter.
        /// </summary>
        /// <param name="filter">The filter expression to apply. If null, retrieves all entities.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a IEnumerable collection of entities that match the filter.</returns>
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
     
        /// <summary>
        /// Retrieves a single entity that matches the specified filter.
        /// </summary>
        /// <param name="filter">The filter expression to apply.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the entity that matches the filter.</returns>
        Task<T> GetSingleAsync(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task AddAsync(T entity);

        /// <summary>
        /// Updates an existing entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Deletes an entity from the repository.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task DeleteAsync(T entity);
    }
}
