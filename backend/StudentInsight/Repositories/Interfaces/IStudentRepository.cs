using StudentInsight.DTOs.Common;
using StudentInsight.DTOs.StudentDTOs;
using StudentInsight.Entities;

namespace StudentInsight.Repositories.Interfaces
{
    public interface IStudentRepository : IGeneralRepository<Student>
    {
        Task<PagedResultDto<Student>> GetAllAsync(StudentFilterDto filterDto);
        
        Task UpdateDepartmentStudentsCount(Guid departmentId);
        Task UpdateDepartmentStudentsCount(Guid departmentId, int count);
    }
}
