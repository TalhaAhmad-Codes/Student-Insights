using Microsoft.EntityFrameworkCore;
using StudentInsight.Data;
using StudentInsight.DTOs.Common;
using StudentInsight.DTOs.UserDTOs;
using StudentInsight.Entities;
using StudentInsight.Repositories.Interfaces;

namespace StudentInsight.Repositories.Implementation
{
    public sealed class UserRepository : GeneralRepository<User>, IUserRepository
    {
        public UserRepository(StudentInsightDbContext dbContext) : base(dbContext) { }

        public async Task<PagedResultDto<User>> GetAllAsync(UserFilterDto filterDto)
        {
            var query = dbSet.AsNoTracking().AsQueryable();

            if (filterDto.Email != null)
                query = query.Where(u => u.Email == filterDto.Email.Trim());

            var items = await GetPagedResultItemsAsync(query.OrderBy(u => u.Id), filterDto.PageNumber, filterDto.PageSize);
            var totalCount = await query.CountAsync();

            return new PagedResultDto<User>()
            {
                Items = items,
                TotalCount = totalCount
            };
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            var result = await GetAllAsync(new()
            {
                Email = email
            });

            return result.TotalCount == 0 ? null : result.Items[0];
        }
    }
}
