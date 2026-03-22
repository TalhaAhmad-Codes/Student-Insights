using StudentInsight.DTOs.Common;
using StudentInsight.DTOs.StudentExamLogsDTOs;
using StudentInsight.Exceptions;
using StudentInsight.Mappers;
using StudentInsight.Repositories.Interfaces;
using StudentInsight.Services.Interfaces;

namespace StudentInsight.Services.Implementation
{
    public sealed class StudentExamLogsService : IStudentExamLogsService
    {
        private readonly IStudentExamLogsRepository repository;

        public StudentExamLogsService(IStudentExamLogsRepository repository)
        {
            this.repository = repository;
        }

        private async void AgainstInValidObtainedMarks(Guid logId, Guid examId)
        {
            int totalMarks = await repository.GetTotalMarks(examId);
            bool valid = await repository.IsValidObtainedMarks(logId, totalMarks);

            if (!valid)
            {
                throw new DomainException($"Obtained marks cannot exceed '{totalMarks}'");
            }
        }

        public async Task<StudentExamLogsResponseDto> CreateAsync(StudentExamLogsCreateDto dto)
        {
            var log = StudentExamLogsMapper.ToEntity(dto);

            AgainstInValidObtainedMarks(log.Id, log.ExamId);

            await repository.AddAsync(log);
            await repository.UpdateExamTotalStudentsEnrolled(log.ExamId, 1);
            return StudentExamLogsMapper.ToDto(log);
        }

        public async Task CreateBulkAsync(List<StudentExamLogsCreateDto> dtos)
        {
            await repository.AddBulkAsync(dtos.Select(StudentExamLogsMapper.ToEntity).ToList());

            // Update the number of students enrolled in corresponding exams
            Dictionary<Guid, bool> map = new();
            foreach (var dto in dtos)
            {
                if (!map.ContainsKey(dto.ExamId))
                {
                    await repository.UpdateExamTotalStudentsEnrolled(dto.ExamId);
                    map[dto.ExamId] = true;
                }
            }
        }

        public async Task<PagedResultDto<StudentExamLogsResponseDto>> GetAllAsync(StudentExamLogsFilterDto filterDto)
        {
            var result = await repository.GetAllAsync(filterDto);

            return new PagedResultDto<StudentExamLogsResponseDto>
            {
                Items = result.Items.Select(StudentExamLogsMapper.ToDto).ToList(),
                TotalCount = result.TotalCount
            };
        }

        public async Task<StudentExamLogsResponseDto?> GetByIdAsync(Guid id)
        {
            var log = await repository.GetByIdAsync(id);

            return log is null ? null : StudentExamLogsMapper.ToDto(log);
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var log = await repository.GetByIdAsync(id);

            if (log is null)
                return false;

            await repository.UpdateExamTotalStudentsEnrolled(log.ExamId, -1);
            await repository.RemoveAsync(log);
            return true;
        }

        public async Task<bool> UpdateAsync(StudentExamLogsUpdateDto dto)
        {
            var log = await repository.GetByIdAsync(dto.Id);

            if (log is null)
                return false;

            // Update the number of students enrolled in the exam
            if (log.ExamId != dto.ExamId)
            {
                // Remove previous
                await repository.UpdateExamTotalStudentsEnrolled(dto.ExamId, -1);

                // Add new
                await repository.UpdateExamTotalStudentsEnrolled(log.ExamId, 1);
            }

            log.Status = dto.Status;
            log.ExamId = dto.ExamId;
            log.StudentId = dto.StudentId;
            log.ObtainedMarks = dto.ObtainedMarks;
            
            AgainstInValidObtainedMarks(log.Id, log.ExamId);

            await repository.UpdateAsync(log);
            return true;
        }
    }
}
