using StudentInsight.DTOs.Common;

namespace StudentInsight.DTOs.StudentDTOs
{
    public sealed class StudentFilterDto : BaseCreatorFilterDto
    {
        public int? FromRollNumber { get; init; }
        public int? ToRollNumber { get; init; }
    }
}
