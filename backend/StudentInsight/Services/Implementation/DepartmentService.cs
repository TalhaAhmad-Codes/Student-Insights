using AutoMapper;
using StudentInsight.DTOs.Common;
using StudentInsight.DTOs.DepartmentDTOs;
using StudentInsight.Entities;
using StudentInsight.Repositories.Interfaces;
using StudentInsight.Services.Interfaces;

namespace StudentInsight.Services.Implementation
{
    public sealed class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository repository;
        private readonly IMapper mapper;

        public DepartmentService(IDepartmentRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<DepartmentResponseDto> CreateAsync(DepartmentCreateDto dto)
        {
            var deparment = mapper.Map<Department>(dto);

            await repository.AddAsync(deparment);
            return mapper.Map<DepartmentResponseDto>(deparment);
        }

        public async Task<PagedResultDto<DepartmentResponseDto>> GetAllAsync(DepartmentFilterDto filterDto)
        {
            var result = await repository.GetAllAsync(filterDto);

            return new PagedResultDto<DepartmentResponseDto>
            {
                Items = mapper.Map<List<DepartmentResponseDto>>(result.Items),
                TotalCount = result.TotalCount
            };
        }

        public async Task<DepartmentResponseDto?> GetByIdAsync(Guid id)
        {
            var department = await repository.GetByIdAsync(id);
            return department is null ? null : mapper.Map<DepartmentResponseDto>(department);
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
