using StudentInsight.DTOs.Common;
using StudentInsight.DTOs.DepartmentDTOs;
using StudentInsight.Entities;

namespace StudentInsight.Repositories.Interfaces
{
    public interface IDepartmentRepository : IGeneralRepository<Department>
    {
        Task<PagedResultDto<Department>> GetAllAsync(DepartmentFilterDto filterDto);
    }
}
