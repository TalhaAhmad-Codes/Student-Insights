using StudentInsight.Models.Common.Request;

namespace StudentInsight.Models.Students.Request
{
    public sealed class StudentCreateRequest : BaseCreatorRequest
    {
        public string StudentName { get; init; }
        public string FatherName { get; init; }
        public int RollNumber { get; init; }
        public DateOnly DateOfBirth { get; init; }
    }
}
