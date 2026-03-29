using StudentInsight.Models.Common.Request;

namespace StudentInsight.Models.Students.Request
{
    public sealed class StudentUpdateRequest : BaseRequest
    {
        public string StudentName { get; init; }
        public int RollNumber { get; init; }
    }
}
