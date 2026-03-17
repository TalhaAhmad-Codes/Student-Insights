using StudentInsight.DTOs.Common;

namespace StudentInsight.DTOs.DepartmentDTOs
{
    public sealed class DepartmentUpdateDto : BaseDto
    {
        private string name;
        public string Name
        {
            get => name;
            init => name = value.Trim().ToLower();
        }
    }
}
