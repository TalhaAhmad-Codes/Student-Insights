using AutoMapper;
using StudentInsight.DTOs.Common;
using StudentInsight.DTOs.StudentExamLogsDTOs;
using StudentInsight.Entities;
using StudentInsight.Exceptions;
using StudentInsight.Repositories.Interfaces;
using StudentInsight.Services.Interfaces;

namespace StudentInsight.Services.Implementation
{
    public sealed class StudentExamLogsService : IStudentExamLogsService
    {
        private readonly IStudentExamLogsRepository repository;
        private readonly IMapper mapper;

        public StudentExamLogsService(IStudentExamLogsRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<StudentExamLogsResponseDto> CreateAsync(StudentExamLogsCreateDto dto)
        {
            var log = mapper.Map<StudentExamLogs>(dto);
            int totalMarks = await repository.GetTotalMarks(log.ExamId);
            bool valid = await repository.IsValidObtainedMarks(log.Id, totalMarks);

            if (!valid)
            {
                throw new DomainException($"Obtained marks cannot exceed '{totalMarks}'");
            }

            await repository.AddAsync(log);
            return mapper.Map<StudentExamLogsResponseDto>(log);
        }

        public async Task<PagedResultDto<StudentExamLogsResponseDto>> GetAllAsync(StudentExamLogsFilterDto filterDto)
        {
            var result = await repository.GetAllAsync(filterDto);

            return new PagedResultDto<StudentExamLogsResponseDto>
            {
                Items = mapper.Map<List<StudentExamLogsResponseDto>>(result.Items),
                TotalCount = result.TotalCount
            };
        }

        public async Task<StudentExamLogsResponseDto?> GetByIdAsync(Guid id)
        {
            var log = await repository.GetByIdAsync(id);

            return log is null ? null : mapper.Map<StudentExamLogsResponseDto>(log);
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var log = await repository.GetByIdAsync(id);

            if (log is null)
                return false;

            await repository.RemoveAsync(log);
            return true;
        }

        public async Task<bool> UpdateAsync(StudentExamLogsUpdateDto dto)
        {
            var log = await repository.GetByIdAsync(dto.Id);

            if (log is null)
                return false;

            log.ObtainedMarks = dto.ObtainedMarks;
            log.Status = dto.Status;
            log.ExamId = dto.ExamId;
            log.StudentId = dto.StudentId;

            await repository.UpdateAsync(log);
            return true;
        }
    }
}
