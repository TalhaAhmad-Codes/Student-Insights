using StudentInsight.DTOs.Common;
using StudentInsight.DTOs.StudentExamLogsDTOs;
using StudentInsight.Entities;
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

        private async Task AgainstInValidObtainedMarks(StudentExamLogs log, Guid examId)
        {
            int totalMarks = await repository.GetTotalMarks(examId);
            bool valid = await repository.IsValidObtainedMarks(log, totalMarks);

            if (!valid)
            {
                throw new DomainException($"Obtained marks cannot exceed '{totalMarks}'");
            }
        }

        public async Task<StudentExamLogsResponseDto> CreateAsync(StudentExamLogsCreateDto dto)
        {
            var log = StudentExamLogsMapper.ToEntity(dto);

            await AgainstInValidObtainedMarks(log, log.ExamId);

            await repository.AddAsync(log, false);
            await repository.UpdateExamTotalStudentsEnrolled(log.ExamId, 1);

            await repository.SaveChangesAsync();
            return StudentExamLogsMapper.ToDto(log);
        }

        public async Task CreateBulkAsync(List<StudentExamLogsCreateDto> dtos)
        {
            await repository.AddBulkAsync(dtos.Select(StudentExamLogsMapper.ToEntity).ToList(), false);

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

            await repository.SaveChangesAsync();
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
            await repository.RemoveAsync(log, false);

            await repository.SaveChangesAsync();
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
            
            await AgainstInValidObtainedMarks(log, log.ExamId);

            await repository.UpdateAsync(log, false);
            
            await repository.SaveChangesAsync();
            return true;
        }

        public async Task<PagedResultDto<StudentExamLogsDetailedResponseDto>> GetAllDetailedAsync(StudentExamLogsFilterDto filterDto)
        {
            var result = await repository.GetAllAsync(filterDto);

            // Converting from Entity -> Detailed DTO
            PagedResultDto<StudentExamLogsDetailedResponseDto> pagedDtos = new()
            {
                TotalCount = result.TotalCount
            };

            foreach (var log in result.Items)
            {
                var dto = await GetDetailedByIdAsync(log.Id);
                pagedDtos.Items.Add(dto!);
            }

            return pagedDtos;
        }

        public async Task<StudentExamLogsDetailedResponseDto?> GetDetailedByIdAsync(Guid id)
        {
            // Get entity
            var log = await repository.GetByIdAsync(id);

            if (log is null) return null;

            // Get DTO
            var dto = StudentExamLogsMapper.ToDetailedDto(log);

            // Get entities from relation
            var exam = await repository.GetExamByIdAsync(dto.ExamId);
            var student = await repository.GetStudentByIdAsync(dto.StudentId);

            if (exam is null)
                throw new DomainException("Selected exam doesn't exist.");

            if (student is null)
                throw new DomainException("Selected student doesn't exist.");

            var studentDepartment = await repository.GetDepartmentByIdAsync(student.DepartmentId);
            var examDepartment = await repository.GetDepartmentByIdAsync(exam.DepartmentId);

            // Updating the DTO
            dto.StudentName = student.StudentName;
            dto.RollNumber = student.RollNumber;
            dto.StudentDepartmentName = studentDepartment!.Name;

            dto.ExamType = exam.Type;
            dto.ExamDepartmentName = examDepartment!.Name;
            dto.TotalMarks = exam.TotalMarks;
            dto.DateOfConduct = exam.ConductedDate;

            dto.Percentage = (double)(dto.ObtainedMarks / dto.TotalMarks) * 100.0;

            return dto;
        }
    }
}
