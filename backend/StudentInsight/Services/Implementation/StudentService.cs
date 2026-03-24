using StudentInsight.DTOs.Common;
using StudentInsight.DTOs.StudentDTOs;
using StudentInsight.Mappers;
using StudentInsight.Repositories.Interfaces;
using StudentInsight.Services.Interfaces;

namespace StudentInsight.Services.Implementation
{
    public sealed class StudentService : IStudentService
    {
        private readonly IStudentRepository repository;

        public StudentService(IStudentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<StudentResponseDto> CreateAsync(StudentCreateDto dto)
        {
            var student = StudentMapper.ToEntity(dto);
            
            await repository.AddAsync(student, false);

            // Update the department "Total Students" count
            await repository.UpdateDepartmentStudentsCount(dto.DepartmentId, 1);
            
            await repository.SaveChangesAsync();
            return StudentMapper.ToDto(student);
        }

        public async Task CreateBulkAsync(List<StudentCreateDto> dtos)
        {
            await repository.AddBulkAsync(dtos.Select(StudentMapper.ToEntity).ToList(), false);

            Dictionary<Guid, bool> map = [];
            foreach (var dto in dtos)
            {
                if (!map.ContainsKey(dto.DepartmentId))
                {
                    // Get all students based on the department
                    var students = await repository.GetAllAsync(new()
                    {
                        DepartmentId = dto.DepartmentId
                    });

                    // Update students count for the department
                    await repository.UpdateDepartmentStudentsCount(dto.DepartmentId, students.TotalCount);
                    
                    // Add the id to dictionary
                    map[dto.DepartmentId] = true;
                }
            }

            await repository.SaveChangesAsync();
        }

        public async Task<PagedResultDto<StudentResponseDto>> GetAllAsync(StudentFilterDto filterDto)
        {
            var result = await repository.GetAllAsync(filterDto);

            return new PagedResultDto<StudentResponseDto>
            {
                Items = result.Items.Select(StudentMapper.ToDto).ToList(),
                TotalCount = result.TotalCount
            };
        }

        public async Task<StudentResponseDto?> GetByIdAsync(Guid id)
        {
            var student = await repository.GetByIdAsync(id);

            return student is null ? null : StudentMapper.ToDto(student);
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var student = await repository.GetByIdAsync(id);

            if (student is null)
                return false;

            await repository.UpdateDepartmentStudentsCount(student.DepartmentId, -1);   // Removes a student count
            await repository.RemoveAsync(student, false);

            await repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(StudentUpdateDto dto)
        {
            var student = await repository.GetByIdAsync(dto.Id);

            if (student is null)
                return false;

            // Update the student count if department has been changed by user
            if (student.DepartmentId != dto.DepartmentId)
            {
                // Remove student (count) from previous department
                await repository.UpdateDepartmentStudentsCount(student.DepartmentId, -1);

                // Add student (count) to new department
                await repository.UpdateDepartmentStudentsCount(dto.DepartmentId, 1);
            }

            student.StudentName = dto.StudentName;
            student.FatherName = dto.FatherName;
            student.RollNumber = dto.RollNumber;
            student.DepartmentId = dto.DepartmentId;
            student.DateOfBirth = dto.DateOfBirth;

            await repository.UpdateAsync(student, false);

            await repository.SaveChangesAsync();
            return true;
        }
    }
}
