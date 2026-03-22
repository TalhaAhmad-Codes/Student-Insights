namespace StudentInsight.Repositories.Interfaces
{
    public interface IGeneralRepository<Entity> where Entity : class
    {
        Task<Entity?> GetByIdAsync(Guid id);
        Task AddAsync(Entity entity, bool canSave = true);
        Task AddBulkAsync(List<Entity> entities, bool canSave = true);
        Task RemoveAsync(Entity entity, bool canSave = true);
        Task UpdateAsync(Entity entity, bool canSave = true);
        Task SaveChangesAsync();
    }
}
