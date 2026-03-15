using Microsoft.EntityFrameworkCore;
using StudentInsight.Data;
using StudentInsight.DTOs.Common;
using StudentInsight.DTOs.StudentDTOs;
using StudentInsight.Entities;
using StudentInsight.Helpers.Utils;
using StudentInsight.Repositories.Interfaces;

namespace StudentInsight.Repositories.Implementation
{
    public sealed class StudentRepository : GeneralRepository<Student>, IStudentRepository
    {
        public StudentRepository(StudentInsightDbContext dbContext) : base(dbContext) { }

        public async Task<PagedResultDto<Student>> GetAllAsync(StudentFilterDto filterDto)
        {
            var query = dbSet.AsQueryable();

            query = query.Where(s => s.CreatorUserId == filterDto.CreatorUserId);

            if (filterDto.DepartmentId.HasValue)
                query = query.Where(s => s.DepartmentId == filterDto.DepartmentId);

            if (filterDto.RollNumber.HasValue)
                query = query.Where(s => s.RollNumber == filterDto.RollNumber);

            if (filterDto.StudentName != null)
                query = query.Where(s => s.StudentName == Func.Trim(filterDto.StudentName, true));

            if (filterDto.FatherName != null)
                query = query.Where(s => s.FatherName == Func.Trim(filterDto.FatherName, true));

            if (filterDto.DateOfBirth.HasValue)
                query = query.Where(s => s.DateOfBirth == filterDto.DateOfBirth);

            var items = await GetPagedResultItemsAsync(query, filterDto.PageNumber, filterDto.PageSize);
            var totalCount = await query.CountAsync();

            return new PagedResultDto<Student>
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
