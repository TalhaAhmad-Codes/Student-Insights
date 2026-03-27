using StudentInsight.DTOs.SubjectDTOs;

namespace StudentInsight.Services.Interfaces
{
    public interface ISubjectService : IBaseService<SubjectRepsonseDto, SubjectCreateDto, SubjectFilterDto, SubjectUpdateDto>
    {
    }
}
