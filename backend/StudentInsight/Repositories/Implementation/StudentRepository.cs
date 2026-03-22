using Microsoft.EntityFrameworkCore;
using StudentInsight.Data;
using StudentInsight.DTOs.Common;
using StudentInsight.DTOs.StudentDTOs;
using StudentInsight.Entities;
using StudentInsight.Exceptions;
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

            if (filterDto.DepartmentId.HasValue)
                query = query.Where(s => s.DepartmentId == filterDto.DepartmentId);

            if (filterDto.FromRollNumber.HasValue)
                query = query.Where(s => s.RollNumber >= filterDto.FromRollNumber);

            if (filterDto.ToRollNumber.HasValue)
                query = query.Where(s => s.RollNumber <= filterDto.ToRollNumber);

            if (filterDto.DateOfBirth.HasValue)
                query = query.Where(s => s.DateOfBirth == filterDto.DateOfBirth);

            var items = await GetPagedResultItemsAsync(query.OrderBy(s => s.Id), filterDto.PageNumber, filterDto.PageSize);
            var totalCount = await query.CountAsync();

            return new PagedResultDto<Student>
            {
                Items = items,
                TotalCount = totalCount
            };
        }

        public async Task UpdateDepartmentStudentsCount(Guid departmentId)
        {
            // Get the department
            var department = await dbContext.Departments.FindAsync(departmentId);

            if (department is null)
                throw new DomainException("Department Not Found!");

            // Get all students from corresponding department
            var students = dbSet.AsQueryable()
                .Where(s => s.DepartmentId == departmentId);

            // Update the students count of the department
            department.TotalStudents = await students.CountAsync();
            dbContext.Departments.Update(department);
            await SaveChangesAsync();
        }

        public async Task UpdateDepartmentStudentsCount(Guid departmentId, int count)
        {
            var department = await dbContext.Departments.FindAsync(departmentId);

            if (department is null)
            {
                throw new DomainException("Department Not Found!");
            }

            // If students count could become negative
            if (department.TotalStudents + count < 0)
            {
                throw new DomainException("Total number of students can't be negative.");
            }

            department.TotalStudents += count;
            dbContext.Departments.Update(department);
            await SaveChangesAsync();
        }
    }
}
