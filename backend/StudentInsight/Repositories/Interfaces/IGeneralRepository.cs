namespace StudentInsight.Repositories.Interfaces
{
    public interface IGeneralRepository<Entity> where Entity : class
    {
        Task<Entity?> GetByIdAsync(Guid id);
        Task AddAsync(Entity entity);
        Task AddBulkAsync(List<Entity> entities);
        Task RemoveAsync(Entity entity);
        Task UpdateAsync(Entity entity);
    }
}
