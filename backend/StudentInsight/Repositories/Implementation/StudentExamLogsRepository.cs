using Microsoft.EntityFrameworkCore;
using StudentInsight.Data;
using StudentInsight.DTOs.Common;
using StudentInsight.DTOs.StudentExamLogsDTOs;
using StudentInsight.Entities;
using StudentInsight.Exceptions;
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

        public async Task<bool> IsValidObtainedMarks(StudentExamLogs log, int totalMarks)
        {
            return log.ObtainedMarks <= totalMarks;
        }

        public async Task UpdateExamTotalStudentsEnrolled(Guid examId)
        {
            var exam = await dbContext.Exams.FindAsync(examId);

            if (exam is null)
            {
                throw new DomainException("Exam not found.");
            }

            var students = dbSet.AsQueryable()
                .Where(l => l.ExamId == examId);

            exam.TotalStudentsEnrolled = await students.CountAsync();
            dbContext.Exams.Update(exam);
            //await SaveChangesAsync();
        }

        public async Task UpdateExamTotalStudentsEnrolled(Guid examId, int count)
        {
            var exam = await dbContext.Exams.FindAsync(examId);

            if (exam is null)
            {
                throw new DomainException("Exam not found.");
            }

            if (exam.TotalStudentsEnrolled + count < 0)
            {
                throw new DomainException("Total number of students enrolled can't be negative.");
            }

            exam.TotalStudentsEnrolled += count;
            dbContext.Exams.Update(exam);
            //await SaveChangesAsync();
        }
    }
}
