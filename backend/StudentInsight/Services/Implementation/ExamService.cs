using StudentInsight.DTOs.Common;
using StudentInsight.DTOs.ExamDTOs;
using StudentInsight.Mappers;
using StudentInsight.Repositories.Interfaces;
using StudentInsight.Services.Interfaces;

namespace StudentInsight.Services.Implementation
{
    public sealed class ExamService : IExamService
    {
        private readonly IExamRepository repository;

        public ExamService(IExamRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ExamResponseDto> CreateAsync(ExamCreateDto dto)
        {
            var exam = ExamMapper.ToEntity(dto);

            await repository.AddAsync(exam);
            return ExamMapper.ToDto(exam);
        }

        public async Task CreateBulkAsync(List<ExamCreateDto> dtos)
        {
            await repository.AddBulkAsync(dtos.Select(ExamMapper.ToEntity).ToList());
        }

        public async Task<PagedResultDto<ExamResponseDto>> GetAllAsync(ExamFilterDto filterDto)
        {
            var result = await repository.GetAllAsync(filterDto);

            return new PagedResultDto<ExamResponseDto>
            {
                Items = result.Items.Select(ExamMapper.ToDto).ToList(),
                TotalCount = result.TotalCount
            };
        }

        public async Task<ExamResponseDto?> GetByIdAsync(Guid id)
        {
            var exam = await repository.GetByIdAsync(id);

            return exam is null ? null : ExamMapper.ToDto(exam);
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
            exam.DateOfConduct = dto.DateOfConduct;
            exam.SubjectId = dto.SubjectId;

            await repository.UpdateAsync(exam);
            return true;
        }
    }
}
