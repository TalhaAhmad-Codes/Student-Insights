using StudentInsight.DTOs.Common;
using StudentInsight.DTOs.ExamDTOs;
using StudentInsight.Entities;

namespace StudentInsight.Repositories.Interfaces
{
    public interface IExamRepository : IGeneralRepository<Exam>
    {
        Task<PagedResultDto<Exam>> GetAllAsync(ExamFilterDto filterDto);
    }
}
