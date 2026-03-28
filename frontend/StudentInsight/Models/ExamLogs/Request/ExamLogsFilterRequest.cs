using StudentInsight.Enums;
using StudentInsight.Models.Common.Request;

namespace StudentInsight.Models.ExamLogs.Request
{
    public sealed class ExamLogsFilterRequest : BaseCreatorFilterRequest
    {
        public int? MinObtainedMarks { get; init; }
        public int? MaxObtainedMarks { get; init; }
        public ExamStatus? Status { get; init; }
        public Guid? StudentId { get; init; }
        public Guid? ExamId { get; init; }
    }
}
