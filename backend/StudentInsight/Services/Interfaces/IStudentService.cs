using StudentInsight.DTOs.StudentDTOs;

namespace StudentInsight.Services.Interfaces
{
    public interface IStudentService : IBaseService<StudentResponseDto, StudentCreateDto, StudentFilterDto, StudentUpdateDto>
    {
    }
}
