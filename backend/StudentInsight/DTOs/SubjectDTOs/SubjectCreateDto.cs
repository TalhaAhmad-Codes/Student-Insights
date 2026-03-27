using StudentInsight.DTOs.Common;

namespace StudentInsight.DTOs.SubjectDTOs
{
    public sealed class SubjectCreateDto : BaseCreatorCreateDto
    {
        private string name;
        
        public string Name
        {
            get => name;
            init => name = value.Trim().ToLower();
        }
    }
}
