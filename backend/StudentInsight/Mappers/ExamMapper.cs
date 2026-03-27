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
                SubjectId = exam.SubjectId,
                DateOfConduct = exam.DateOfConduct,
                CreatedAt = exam.CreatedAt
            };

        public static Exam ToEntity(ExamCreateDto dto)
            => new()
            {
                CreatorUserId = dto.CreatorUserId,
                Type = dto.Type,
                TotalMarks = dto.TotalMarks,
                SubjectId = dto.SubjectId,
                DateOfConduct = dto.DateOfConduct
            };
    }
}
