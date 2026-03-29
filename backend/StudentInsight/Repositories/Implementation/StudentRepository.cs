using Microsoft.EntityFrameworkCore;
using StudentInsight.Data;
using StudentInsight.DTOs.Common;
using StudentInsight.DTOs.StudentDTOs;
using StudentInsight.Entities;
using StudentInsight.Repositories.Interfaces;

namespace StudentInsight.Repositories.Implementation
{
    public sealed class StudentRepository : GeneralRepository<Student>, IStudentRepository
    {
        public StudentRepository(StudentInsightDbContext dbContext) : base(dbContext) { }

        public async Task<PagedResultDto<Student>> GetAllAsync(StudentFilterDto filterDto)
        {
            var query = dbSet.AsNoTracking().AsQueryable();

            if (filterDto.CreatorUserId.HasValue)
                query = query.Where(s => s.CreatorUserId == filterDto.CreatorUserId);

            if (filterDto.FromRollNumber.HasValue)
                query = query.Where(s => s.RollNumber >= filterDto.FromRollNumber);

            if (filterDto.ToRollNumber.HasValue)
                query = query.Where(s => s.RollNumber <= filterDto.ToRollNumber);

            var items = await GetPagedResultItemsAsync(query.OrderBy(s => s.Id), filterDto.PageNumber, filterDto.PageSize);
            var totalCount = await query.CountAsync();

            return new PagedResultDto<Student>
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
