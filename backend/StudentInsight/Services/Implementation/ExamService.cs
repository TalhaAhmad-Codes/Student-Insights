using AutoMapper;
using StudentInsight.DTOs.Common;
using StudentInsight.DTOs.ExamDTOs;
using StudentInsight.Entities;
using StudentInsight.Repositories.Interfaces;
using StudentInsight.Services.Interfaces;

namespace StudentInsight.Services.Implementation
{
    public sealed class ExamService : IExamService
    {
        private readonly IExamRepository repository;
        private readonly IMapper mapper;

        public ExamService(IExamRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ExamResponseDto> CreateAsync(ExamCreateDto dto)
        {
            var exam = mapper.Map<Exam>(dto);

            await repository.AddAsync(exam);
            return mapper.Map<ExamResponseDto>(exam);
        }

        public async Task<PagedResultDto<ExamResponseDto>> GetAllAsync(ExamFilterDto filterDto)
        {
            var result = await repository.GetAllAsync(filterDto);

            return new PagedResultDto<ExamResponseDto>
            {
                Items = mapper.Map<List<ExamResponseDto>>(result.Items),
                TotalCount = result.TotalCount
            };
        }

        public async Task<ExamResponseDto?> GetByIdAsync(Guid id)
        {
            var exam = await repository.GetByIdAsync(id);

            return exam is null ? null : mapper.Map<ExamResponseDto>(exam);
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var exam = await repository.GetByIdAsync(id);

            if (exam is null)
                return false;

            await repository.RemoveAsync(exam);
            return true;
        }

        public async Task<bool> UpdateAsync(ExamUpdateDto dto)
        {
            var exam = await repository.GetByIdAsync(dto.Id);

            if (exam is null)
                return false;

            exam.TotalMarks = dto.TotalMarks;
            exam.Type = dto.Type;
            exam.ConductedDate = dto.ConductedDate;
            exam.DepartmentId = dto.DepartmentId;

            await repository.UpdateAsync(exam);
            return true;
        }
    }
}
