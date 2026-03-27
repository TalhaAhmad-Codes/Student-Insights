using StudentInsight.DTOs.Common;
using StudentInsight.DTOs.SubjectDTOs;
using StudentInsight.Mappers;
using StudentInsight.Repositories.Interfaces;
using StudentInsight.Services.Interfaces;

namespace StudentInsight.Services.Implementation
{
    public sealed class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository repository;

        public SubjectService(ISubjectRepository repository)
        {
            this.repository = repository;
        }

        public async Task<SubjectRepsonseDto> CreateAsync(SubjectCreateDto dto)
        {
            var subject = SubjectMapper.ToEntity(dto);
            await repository.AddAsync(subject);
            return SubjectMapper.ToDto(subject);
        }

        public async Task CreateBulkAsync(List<SubjectCreateDto> dtos)
        {
            await repository.AddBulkAsync(dtos.Select(SubjectMapper.ToEntity).ToList());
        }

        public async Task<PagedResultDto<SubjectRepsonseDto>> GetAllAsync(SubjectFilterDto filterDto)
        {
            var result = await repository.GetAllAsync(filterDto);
            return new PagedResultDto<SubjectRepsonseDto>()
            {
                Items = result.Items.Select(SubjectMapper.ToDto).ToList(),
                TotalCount = result.TotalCount
            };
        }

        public async Task<SubjectRepsonseDto?> GetByIdAsync(Guid id)
        {
            var subject = await repository.GetByIdAsync(id);
            return subject is null ? null : SubjectMapper.ToDto(subject);
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var subject = await repository.GetByIdAsync(id);

            if (subject is null)
            {
                return false;
            }

            await repository.RemoveAsync(subject);
            return true;
        }

        public async Task<bool> UpdateAsync(SubjectUpdateDto dto)
        {
            var subject = await repository.GetByIdAsync(dto.Id);

            if (subject is null)
            {
                return false;
            }

            subject.Name = dto.Name;

            await repository.UpdateAsync(subject);
            return true;
        }
    }
}
