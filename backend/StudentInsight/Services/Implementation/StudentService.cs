using AutoMapper;
using StudentInsight.DTOs.Common;
using StudentInsight.DTOs.StudentDTOs;
using StudentInsight.Entities;
using StudentInsight.Repositories.Interfaces;
using StudentInsight.Services.Interfaces;

namespace StudentInsight.Services.Implementation
{
    public sealed class StudentService : IStudentService
    {
        private readonly IStudentRepository repository;
        private readonly IMapper mapper;

        public StudentService(IStudentRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<StudentResponseDto> CreateAsync(StudentCreateDto dto)
        {
            var student = mapper.Map<Student>(dto);
            
            await repository.AddAsync(student);
            return mapper.Map<StudentResponseDto>(student);
        }

        public async Task<PagedResultDto<StudentResponseDto>> GetAllAsync(StudentFilterDto filterDto)
        {
            var result = await repository.GetAllAsync(filterDto);

            return new PagedResultDto<StudentResponseDto>
            {
                Items = mapper.Map<List<StudentResponseDto>>(result.Items),
                TotalCount = result.TotalCount
            };
        }

        public async Task<StudentResponseDto?> GetByIdAsync(Guid id)
        {
            var student = await repository.GetByIdAsync(id);

            return student is null ? null : mapper.Map<StudentResponseDto?>(student);
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
            student.FatherName = dto.FatherName;
            student.RollNumber = dto.RollNumber;
            student.DepartmentId = dto.DepartmentId;
            student.DateOfBirth = dto.DateOfBirth;

            await repository.UpdateAsync(student);
            return true;
        }
    }
}
