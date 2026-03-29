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
            
            await repository.AddAsync(student);
            return StudentMapper.ToDto(student);
        }

        public async Task CreateBulkAsync(List<StudentCreateDto> dtos)
        {
            await repository.AddBulkAsync(dtos.Select(StudentMapper.ToEntity).ToList());
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

            await repository.RemoveAsync(student);
            return true;
        }

        public async Task<bool> UpdateAsync(StudentUpdateDto dto)
        {
            var student = await repository.GetByIdAsync(dto.Id);

            if (student is null)
                return false;

            student.StudentName = dto.StudentName;
            student.RollNumber = dto.RollNumber;

            await repository.UpdateAsync(student);
            return true;
        }
    }
}
