using StudentInsight.DTOs.Common;

namespace StudentInsight.Services.Interfaces
{
    // For those which might include PATCH endpoints only
    public interface IBaseService<RDto, CDto, FDto> where RDto : class
    {
        Task<RDto?> GetByIdAsync(Guid id);
        Task<PagedResultDto<RDto>> GetAllAsync(FDto filterDto);

        Task<RDto> CreateAsync(CDto dto);
        Task CreateBulkAsync(List<CDto> dtos);
        Task<bool> RemoveAsync(Guid id);
    }

    // For those which might also include PUT endpoints
    public interface IBaseService<RDto, CDto, FDto, UDto> : IBaseService<RDto, CDto, FDto> where RDto : class
    {
        Task<bool> UpdateAsync(UDto dto);
    }
}
