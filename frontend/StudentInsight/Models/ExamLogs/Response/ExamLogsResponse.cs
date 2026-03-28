using StudentInsight.Enums;
using StudentInsight.Models.Common.Response;

namespace StudentInsight.Models.ExamLogs.Response
{
    public class ExamLogsResponse : BaseCreatorResponse
    {
        public int ObtainedMarks { get; init; }
        public ExamStatus Status { get; init; }
        public string? Note { get; init; }
        public Guid StudentId { get; init; }
        public Guid ExamId { get; init; }

    }
}
