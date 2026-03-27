using Microsoft.EntityFrameworkCore;
using StudentInsight.Data;
using StudentInsight.DTOs.Common;
using StudentInsight.DTOs.SubjectDTOs;
using StudentInsight.Entities;
using StudentInsight.Repositories.Interfaces;

namespace StudentInsight.Repositories.Implementation
{
    public sealed class SubjectRepository : GeneralRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(StudentInsightDbContext context) : base(context) { }

        public async Task<PagedResultDto<Subject>> GetAllAsync(SubjectFilterDto filterDto)
        {
            var query = dbSet.AsQueryable();

            if (filterDto.CreatorUserId.HasValue)
                query = query.Where(s => s.CreatorUserId ==  filterDto.CreatorUserId.Value);

            if (filterDto.Name != null)
                query = query.Where(s => s.Name == filterDto.Name);

            var items = await GetPagedResultItemsAsync(query, filterDto.PageNumber, filterDto.PageSize);
            var totalCount = await query.CountAsync();

            return new PagedResultDto<Subject>()
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
