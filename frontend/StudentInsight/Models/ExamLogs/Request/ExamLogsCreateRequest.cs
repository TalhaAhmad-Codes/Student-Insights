using StudentInsight.Enums;
using StudentInsight.Models.Common.Request;

namespace StudentInsight.Models.ExamLogs.Request
{
    public sealed class ExamLogsCreateRequest : BaseCreatorRequest
    {
        public int ObtainedMarks { get; init; }
        public ExamStatus Status { get; init; }
        public string? Note { get; init; }
        public Guid StudentId { get; init; }
        public Guid ExamId { get; init; }
    }
}
