using AutoMapper;
using StudentInsight.DTOs.DepartmentDTOs;
using StudentInsight.DTOs.ExamDTOs;
using StudentInsight.DTOs.StudentDTOs;
using StudentInsight.DTOs.StudentExamLogsDTOs;
using StudentInsight.DTOs.UserDTOs;
using StudentInsight.Entities;

namespace StudentInsight.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User
            CreateMap<UserCreateDto, User>();
            CreateMap<User, UserResponseDto>();

            // Student
            CreateMap<StudentCreateDto, Student>();
            CreateMap<Student, StudentResponseDto>();

            // Department
            CreateMap<DepartmentCreateDto, Department>();
            CreateMap<Department, DepartmentResponseDto>();

            // Exam
            CreateMap<ExamCreateDto, Exam>();
            CreateMap<Exam, ExamResponseDto>();

            // Student Exam Logs
            CreateMap<StudentExamLogsCreateDto, StudentExamLogs>();
            CreateMap<StudentExamLogs, StudentExamLogsResponseDto>();
        }
    }
}
