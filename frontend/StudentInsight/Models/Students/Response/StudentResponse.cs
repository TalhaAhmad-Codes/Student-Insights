using StudentInsight.Models.Common.Response;

namespace StudentInsight.Models.Students.Response
{
    public sealed class StudentResponse : BaseCreatorResponse
    {
        public string StudentName { get; init; }
        public int RollNumber { get; init; }
    }
}
