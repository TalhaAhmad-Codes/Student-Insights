using Microsoft.EntityFrameworkCore;
using StudentInsight.Data;
using StudentInsight.DTOs.Common;
using StudentInsight.DTOs.UserDTOs;
using StudentInsight.Entities;
using StudentInsight.Helpers.Utils;
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
    }
}
