using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using StudentInsight.Data;
using StudentInsight.Repositories.Interfaces;

namespace StudentInsight.Repositories.Implementation
{
    public abstract class GeneralRepository<Entity> : IGeneralRepository<Entity> where Entity : class 
    {
        protected readonly StudentInsightDbContext dbContext;
        protected readonly DbSet<Entity> dbSet;

        protected GeneralRepository(StudentInsightDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<Entity>();
        }

        // Get entity by its Id
        public async Task<Entity?> GetByIdAsync(Guid id)
            => await dbSet.FindAsync(id);

        // Add an entity to the database
        public async Task AddAsync(Entity entity, bool canSave)
        {
            await dbSet.AddAsync(entity);

            if (canSave)
                await SaveChangesAsync();
        }

        // Delete an entity from the database
        public async Task RemoveAsync(Entity entity, bool canSave)
        {
            dbSet.Remove(entity);

            if (canSave)
                await SaveChangesAsync();
        }

        // Update an entity into database
        public async Task UpdateAsync(Entity entity, bool canSave)
        {
            dbSet.Update(entity);

            if (canSave)
                await SaveChangesAsync();
        }

        // Get paged result items
        protected async Task<List<Entity>> GetPagedResultItemsAsync(IQueryable<Entity> query, int pageNumber, int pageSize)
        {
            pageNumber = Math.Max(pageNumber, 1);
            pageSize = Math.Max(pageSize, 1);

            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public async Task AddBulkAsync(List<Entity> entities, bool canSave = true)
        {
            await dbContext.BulkInsertAsync(entities);

            if (canSave)
                await SaveChangesAsync();
        }
    }
}
