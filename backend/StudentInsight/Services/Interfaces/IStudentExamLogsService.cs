using StudentInsight.DTOs.StudentExamLogsDTOs;

namespace StudentInsight.Services.Interfaces
{
    public interface IStudentExamLogsService : IBaseService<StudentExamLogsResponseDto, StudentExamLogsCreateDto, StudentExamLogsFilterDto, StudentExamLogsUpdateDto>
    {
    }
}
