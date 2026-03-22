using StudentInsight.DTOs.Common;
using StudentInsight.DTOs.StudentExamLogsDTOs;
using StudentInsight.Entities;

namespace StudentInsight.Repositories.Interfaces
{
    public interface IStudentExamLogsRepository : IGeneralRepository<StudentExamLogs>
    {
        Task<PagedResultDto<StudentExamLogs>> GetAllAsync(StudentExamLogsFilterDto filterDto);
        
        Task<int> GetTotalMarks(Guid examId);
        Task<bool> IsValidObtainedMarks(Guid logId, int totalMarks);

        Task UpdateExamTotalStudentsEnrolled(Guid examId);
        Task UpdateExamTotalStudentsEnrolled(Guid examId, int count);
    }
}
