using StudentInsight.DTOs.Common;
using StudentInsight.DTOs.StudentExamLogsDTOs;

namespace StudentInsight.Services.Interfaces
{
    public interface IStudentExamLogsService : IBaseService<StudentExamLogsResponseDto, StudentExamLogsCreateDto, StudentExamLogsFilterDto, StudentExamLogsUpdateDto>
    {
        Task<PagedResultDto<StudentExamLogsDetailedResponseDto>> GetAllDetailedAsync(StudentExamLogsFilterDto filterDto);

        Task<StudentExamLogsDetailedResponseDto?> GetDetailedByIdAsync(Guid id);
    }
}
