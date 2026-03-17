using StudentInsight.DTOs.StudentDTOs;
using StudentInsight.Entities;

namespace StudentInsight.Mappers
{
    public static class StudentMapper
    {
        public static StudentResponseDto ToDto(Student student)
            => new()
            {
                CreatorUserId = student.CreatorUserId,
                Id = student.Id,
                RollNumber = student.RollNumber,
                StudentName = student.StudentName,
                FatherName = student.FatherName,
                DepartmentId = student.DepartmentId,
                DateOfBirth = student.DateOfBirth,
                CreatedAt = student.CreatedAt
            };

        public static Student ToEntity(StudentCreateDto dto)
            => new()
            {
                CreatorUserId = dto.CreatorUserId,
                RollNumber = dto.RollNumber,
                StudentName = dto.StudentName,
                FatherName = dto.FatherName,
                DepartmentId = dto.DepartmentId,
                DateOfBirth = dto.DateOfBirth
            };
    }
}
