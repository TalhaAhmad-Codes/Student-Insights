using StudentInsight.DTOs.Common;

namespace StudentInsight.DTOs.DepartmentDTOs
{
    public sealed class DepartmentCreateDto : BaseCreatorCreateDto
    {
        private string name;
        public string Name
        {
            get => name;
            init => name = value.Trim().ToLower();
        }
    }
}
