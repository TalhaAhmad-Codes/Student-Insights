using StudentInsight.DTOs.DepartmentDTOs;

namespace StudentInsight.Services.Interfaces
{
    public interface IDepartmentService : IBaseService<DepartmentResponseDto, DepartmentCreateDto, DepartmentFilterDto, DepartmentUpdateDto>
    {
    }
}
