using StudentInsight.DTOs.DepartmentDTOs;
using StudentInsight.Entities;

namespace StudentInsight.Mappers
{
    public static class DepartmentMapper
    {
        public static DepartmentResponseDto ToDto(Department department)
            => new()
            {
                CreatorUserId = department.CreatorUserId,
                Id = department.Id,
                Name = department.Name,
                TotalStudents = department.TotalStudents,
                CreatedAt = department.CreatedAt
            };

        public static Department ToEntity(DepartmentCreateDto dto)
            => new()
            {
                CreatorUserId = dto.CreatorUserId,
                Name = dto.Name
            };
    }
}
