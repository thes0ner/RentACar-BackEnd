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
        IQueryable<T> GetAll(bool tracking = true);

        IQueryable<T> GetFiltered(Expression<Func<T, bool>> filter, bool tracking = true);

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
