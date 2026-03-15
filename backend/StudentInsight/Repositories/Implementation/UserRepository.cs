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
            var query = dbSet.AsQueryable();

            if (filterDto.Email != null)
                query = query.Where(u => u.Email == Func.Trim(filterDto.Email));

            var items = await GetPagedResultItemsAsync(query, filterDto.PageNumber, filterDto.PageSize);
            var totalCount = await query.CountAsync();

            return new PagedResultDto<User>()
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
