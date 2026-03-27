using Microsoft.EntityFrameworkCore;
using StudentInsight.Data;
using StudentInsight.DTOs.Common;
using StudentInsight.DTOs.ExamDTOs;
using StudentInsight.Entities;
using StudentInsight.Repositories.Interfaces;

namespace StudentInsight.Repositories.Implementation
{
    public sealed class ExamRepository : GeneralRepository<Exam>, IExamRepository
    {
        public ExamRepository(StudentInsightDbContext dbContext) : base(dbContext) { }

        public async Task<PagedResultDto<Exam>> GetAllAsync(ExamFilterDto filterDto)
        {
            var query = dbSet.AsNoTracking().AsQueryable();

            if (filterDto.CreatorUserId.HasValue)
                query = query.Where(e => e.CreatorUserId == filterDto.CreatorUserId);

            if (filterDto.SubjectId.HasValue)
                query = query.Where(e => e.SubjectId == filterDto.SubjectId);

            if (filterDto.Type.HasValue)
                query = query.Where(e => e.Type == filterDto.Type);

            if (filterDto.FromConductedDate.HasValue)
                query = query.Where(e => e.DateOfConduct >= filterDto.FromConductedDate);

            if (filterDto.ToConductedDate.HasValue)
                query = query.Where(e => e.DateOfConduct <= filterDto.ToConductedDate);

            if (filterDto.MinTotalMarks.HasValue)
                query = query.Where(e => e.TotalMarks >= filterDto.MinTotalMarks);

            if (filterDto.MaxTotalMarks.HasValue)
                query = query.Where(e => e.TotalMarks <= filterDto.MaxTotalMarks);

            var items = await GetPagedResultItemsAsync(query.OrderBy(e => e.Id), filterDto.PageNumber, filterDto.PageSize);
            var totalCount = await query.CountAsync();

            return new PagedResultDto<Exam>
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
