using Microsoft.EntityFrameworkCore;
using StudentInsight.Data;
using StudentInsight.DTOs.Common;
using StudentInsight.DTOs.StudentExamLogsDTOs;
using StudentInsight.Entities;
using StudentInsight.Repositories.Interfaces;

namespace StudentInsight.Repositories.Implementation
{
    public sealed class StudentExamLogsRepository : GeneralRepository<StudentExamLogs>, IStudentExamLogsRepository
    {
        public StudentExamLogsRepository(StudentInsightDbContext dbContext) : base(dbContext) { }

        public async Task<PagedResultDto<StudentExamLogs>> GetAllAsync(StudentExamLogsFilterDto filterDto)
        {
            var query = dbSet.AsNoTracking().AsQueryable();

            if (filterDto.CreatorUserId.HasValue)
                query = query.Where(l => l.CreatorUserId == filterDto.CreatorUserId);

            if (filterDto.ExamId.HasValue)
                query = query.Where(l => l.ExamId == filterDto.ExamId);

            if (filterDto.StudentId.HasValue)
                query = query.Where(l => l.StudentId == filterDto.StudentId);

            if (filterDto.MinObtainedMarks.HasValue)
                query = query.Where(l => l.ObtainedMarks >= filterDto.MinObtainedMarks);

            if (filterDto.MaxObtainedMarks.HasValue)
                query = query.Where(l => l.ObtainedMarks <= filterDto.MaxObtainedMarks);

            if (filterDto.Status.HasValue)
                query = query.Where(l => l.Status == filterDto.Status);

            var items = await GetPagedResultItemsAsync(query.OrderBy(l => l.Id), filterDto.PageNumber, filterDto.PageSize);
            var totalCount = await query.CountAsync();

            return new PagedResultDto<StudentExamLogs>
            {
                Items = items,
                TotalCount = totalCount
            };
        }

        public async Task<int> GetTotalMarks(Guid examId)
        {
            var exam = await dbContext.Exams.FindAsync(examId);

            return exam is null ? 0 : exam.TotalMarks;
        }

        public async Task<bool> IsValidObtainedMarks(Guid logId, int totalMarks)
        {
            var log = await GetByIdAsync(logId);

            if (log is null)
                return false;

            return log.ObtainedMarks <= totalMarks;
        }
    }
}
