using Microsoft.EntityFrameworkCore;
using RentACar.Core.Entities.Abstract;
using RentACar.Core.Entities.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.DataAccess.Repositories.EntityFrameworkRepository.Abstract
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        protected readonly TContext _context;

        public EfEntityRepositoryBase(TContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetAll(bool tracking = true)
        {

            // Initialize the query from the DbSet as IQueryable
            var query = _context.Set<TEntity>().AsQueryable();

            // Disable change tracking if tracking is false
            if (!tracking)
                query = query.AsNoTracking();

            // Return the final query for further use
            return query;

        }

        public IQueryable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> filter, bool tracking = true)
        {

            // Start with the base query from the DbSet
            var query = _context.Set<TEntity>().AsQueryable();

            // Apply the filter to the query
            query = query.Where(filter);

            // Disable change tracking if tracking is false
            if (!tracking)
                query = query.AsNoTracking();

            // Return the filtered query (expecting a single result)
            return query;


        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter, bool tracking = true)
        {

            // Start with the base query from the DbSet
            var query = _context.Set<TEntity>().AsQueryable();

            // Apply the filter (predicate) to the query
            query = query.Where(filter);

            // Disable change tracking if tracking is false
            if (!tracking)
                query = query.AsNoTracking();

            // Execute the query asynchronously and return the single result
            return await query.FirstOrDefaultAsync();

        }


        public async Task AddAsync(TEntity entity)
        {
            // Track the entity to be added
            var addedEntity = _context.Entry(entity);

            // Set the entity state to 'Added' for insertion
            addedEntity.State = EntityState.Added;

            // Save changes to the database asynchronously
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {

            // Track the entity to be deleted
            var deletedEntity = _context.Entry(entity);

            // Set the entity state to 'Deleted' for removal
            deletedEntity.State = EntityState.Deleted;

            // Save changes to the database asynchronously
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            // Track the entity to be updated
            var updatedEntity = _context.Entry(entity);

            // Set the entity state to 'Modified' for updates
            updatedEntity.State = EntityState.Modified;

            // Save changes to the database asynchronously
            await _context.SaveChangesAsync();
        }

    }
}
