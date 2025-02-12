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
        /// Retrieves all entities as an IQueryable.
        /// </summary>
        /// <param name="tracking">If true, enables change tracking (default). If false, disables it for read-only operations.</param>
        /// <returns>An IQueryable of all entities.</returns>
        IQueryable<T> GetAll(bool tracking = true);

        /// <summary>
        /// Retrieves entities filtered by a condition as an IQueryable.
        /// </summary>
        /// <param name="filter">A lambda expression to filter the entities.</param>
        /// <param name="tracking">If true, enables change tracking (default). If false, disables it for read-only operations.</param>
        /// <returns>An IQueryable of filtered entities.</returns>
        IQueryable<T> GetFiltered(Expression<Func<T, bool>> filter, bool tracking = true);

        /// <summary>
        /// Retrieves a single entity asynchronously based on a filter condition.
        /// </summary>
        /// <param name="filter">A lambda expression to filter the entity.</param>
        /// <param name="tracking">If true, enables change tracking (default). If false, disables it for read-only operations.</param>
        /// <returns>A Task<T> representing the asynchronous operation, containing the matched entity or null if not found.</returns>
        Task<T> GetSingleAsync(Expression<Func<T, bool>> filter, bool tracking = true);

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
