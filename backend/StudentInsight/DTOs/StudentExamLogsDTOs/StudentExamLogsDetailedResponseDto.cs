using StudentInsight.Enums;

namespace StudentInsight.DTOs.StudentExamLogsDTOs
{
    public sealed class StudentExamLogsDetailedResponseDto : StudentExamLogsResponseDto
    {
        // Student
        public string StudentName { get; set; }
        public int RollNumber { get; set; }
        public float Percentage { get; set; }

        // Exam
        public ExamType ExamType { get; set; }
        public string SubjectName { get; set; }
        public int TotalMarks { get; set; }
        public DateOnly DateOfConduct { get; set; }
    }
}
