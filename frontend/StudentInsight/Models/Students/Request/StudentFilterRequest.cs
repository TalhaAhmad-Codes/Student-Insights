using StudentInsight.Models.Common.Request;

namespace StudentInsight.Models.Students.Request
{
    public sealed class StudentFilterRequest : BaseCreatorFilterRequest
    {
        public int? FromRollNumber { get; init; }
        public int? ToRollNumber { get; init; }
        public DateOnly? DateOfBirth { get; init; }
    }
}
