using StudentInsight.DTOs.Common;
using StudentInsight.DTOs.StudentExamLogsDTOs;
using StudentInsight.Entities;

namespace StudentInsight.Repositories.Interfaces
{
    public interface IStudentExamLogsRepository : IGeneralRepository<StudentExamLogs>
    {
        Task<PagedResultDto<StudentExamLogs>> GetAllAsync(StudentExamLogsFilterDto filterDto);
    }
}
