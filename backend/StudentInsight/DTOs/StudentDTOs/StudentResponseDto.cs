using StudentInsight.DTOs.Common;

namespace StudentInsight.DTOs.StudentDTOs
{
    public sealed class StudentResponseDto : BaseCreatorDto
    {
        public string StudentName { get; init; }
        public int RollNumber { get; init; }
    }
}
