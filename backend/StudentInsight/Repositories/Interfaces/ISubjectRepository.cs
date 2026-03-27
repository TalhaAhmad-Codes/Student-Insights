using StudentInsight.DTOs.Common;
using StudentInsight.DTOs.SubjectDTOs;
using StudentInsight.Entities;

namespace StudentInsight.Repositories.Interfaces
{
    public interface ISubjectRepository : IGeneralRepository<Subject>
    {
        Task<PagedResultDto<Subject>> GetAllAsync(SubjectFilterDto filterDto);
    }
}
