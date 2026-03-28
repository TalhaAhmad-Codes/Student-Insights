using StudentInsight.Enums;

namespace StudentInsight.Models.ExamLogs.Response
{
    public sealed class ExamLogsDetailedResponse : ExamLogsResponse
    {
        // Student
        public string StudentName { get; init; }
        public int RollNumber { get; init; }
        public float Percentage { get; init; }

        // Exam
        public ExamType ExamType { get; init; }
        public string SubjectName { get; init; }
        public int TotalMarks { get; init; }
        public DateOnly DateOfConduct { get; init; }
    }
}
