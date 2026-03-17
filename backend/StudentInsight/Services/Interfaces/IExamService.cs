using StudentInsight.DTOs.ExamDTOs;

namespace StudentInsight.Services.Interfaces
{
    public interface IExamService : IBaseService<ExamResponseDto, ExamCreateDto, ExamFilterDto, ExamUpdateDto>
    {
    }
}
