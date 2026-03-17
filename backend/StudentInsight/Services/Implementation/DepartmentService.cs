using StudentInsight.DTOs.Common;
using StudentInsight.DTOs.DepartmentDTOs;
using StudentInsight.Mappers;
using StudentInsight.Repositories.Interfaces;
using StudentInsight.Services.Interfaces;

namespace StudentInsight.Services.Implementation
{
    public sealed class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository repository;

        public DepartmentService(IDepartmentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DepartmentResponseDto> CreateAsync(DepartmentCreateDto dto)
        {
            var deparment = DepartmentMapper.ToEntity(dto);

            await repository.AddAsync(deparment);
            return DepartmentMapper.ToDto(deparment);
        }

        public async Task CreateBulkAsync(List<DepartmentCreateDto> dtos)
        {
            await repository.AddBulkAsync(dtos.Select(DepartmentMapper.ToEntity).ToList());
        }

        public async Task<PagedResultDto<DepartmentResponseDto>> GetAllAsync(DepartmentFilterDto filterDto)
        {
            var result = await repository.GetAllAsync(filterDto);

            return new PagedResultDto<DepartmentResponseDto>
            {
                Items = result.Items.Select(DepartmentMapper.ToDto).ToList(),
                TotalCount = result.TotalCount
            };
        }

        public async Task<DepartmentResponseDto?> GetByIdAsync(Guid id)
        {
            var department = await repository.GetByIdAsync(id);
            return department is null ? null : DepartmentMapper.ToDto(department);
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var department = await repository.GetByIdAsync(id);
            
            if (department is null)
                return false;

            await repository.RemoveAsync(department);
            return true;
        }

        public async Task<bool> UpdateAsync(DepartmentUpdateDto dto)
        {
            var department = await repository.GetByIdAsync(dto.Id);

            if (department is null)
                return false;

            department.Name = dto.Name;

            await repository.UpdateAsync(department);
            return true;
        }
    }
}
