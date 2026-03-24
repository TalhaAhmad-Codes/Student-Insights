using StudentInsight.DTOs.ExamDTOs;
using StudentInsight.Entities;

namespace StudentInsight.Mappers
{
    public static class ExamMapper
    {
        public static ExamResponseDto ToDto(Exam exam)
            => new()
            {
                CreatorUserId = exam.CreatorUserId,
                Id = exam.Id,
                Type = exam.Type,
                TotalMarks = exam.TotalMarks,
                TotalStudentsEnrolled = exam.TotalStudentsEnrolled,
                DepartmentId = exam.DepartmentId,
                ConductedDate = exam.ConductedDate,
                CreatedAt = exam.CreatedAt
            };

        public static Exam ToEntity(ExamCreateDto dto)
            => new()
            {
                CreatorUserId = dto.CreatorUserId,
                Type = dto.Type,
                TotalMarks = dto.TotalMarks,
                DepartmentId = dto.DepartmentId,
                ConductedDate = dto.ConductedDate
            };
    }
}
