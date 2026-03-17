using Microsoft.EntityFrameworkCore;
using StudentInsight.Data;
using StudentInsight.DTOs.Common;
using StudentInsight.DTOs.DepartmentDTOs;
using StudentInsight.Entities;
using StudentInsight.Helpers.Utils;
using StudentInsight.Repositories.Interfaces;

namespace StudentInsight.Repositories.Implementation
{
    public sealed class DepartmentRepository : GeneralRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(StudentInsightDbContext dbContext) : base(dbContext) { }

        public async Task<PagedResultDto<Department>> GetAllAsync(DepartmentFilterDto filterDto)
        {
            var query = dbSet.AsNoTracking().AsQueryable();

            query = query.Where(d => d.CreatorUserId == filterDto.CreatorUserId);

            if (filterDto.Name != null)
                query = query.Where(d => d.Name == filterDto.Name.Trim().ToLower());

            var items = await GetPagedResultItemsAsync(query.OrderBy(d => d.Id), filterDto.PageNumber, filterDto.PageSize);
            var totalCount = await query.CountAsync();

            return new PagedResultDto<Department>
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
