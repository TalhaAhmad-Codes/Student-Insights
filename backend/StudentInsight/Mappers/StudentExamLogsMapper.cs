using StudentInsight.DTOs.StudentExamLogsDTOs;
using StudentInsight.Entities;

namespace StudentInsight.Mappers
{
    public static class StudentExamLogsMapper
    {
        public static StudentExamLogsResponseDto ToDto(StudentExamLogs logs)
            => new()
            {
                CreatorUserId = logs.CreatorUserId,
                Id = logs.Id,
                ExamId = logs.ExamId,
                StudentId = logs.StudentId,
                ObtainedMarks = logs.ObtainedMarks,
                Status = logs.Status,
                Note = logs.Note,
                CreatedAt = logs.CreatedAt
            };

        public static StudentExamLogsDetailedResponseDto ToDetailedDto(StudentExamLogs logs)
            => new()
            {
                CreatorUserId = logs.CreatorUserId,
                Id = logs.Id,
                ExamId = logs.ExamId,
                StudentId = logs.StudentId,
                ObtainedMarks = logs.ObtainedMarks,
                Status = logs.Status,
                Note = logs.Note,
                CreatedAt = logs.CreatedAt
            };

        public static StudentExamLogs ToEntity(StudentExamLogsCreateDto dto)
            => new()
            {
                CreatorUserId = dto.CreatorUserId,
                ExamId = dto.ExamId,
                StudentId = dto.StudentId,
                ObtainedMarks = dto.ObtainedMarks,
                Status = dto.Status,
                Note = dto.Note
            };
    }
}
