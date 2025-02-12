using Microsoft.EntityFrameworkCore;
using RentACar.Core.Entities.Abstract;
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
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }


    }
}
