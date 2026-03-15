using StudentInsight.DTOs.Common;
using StudentInsight.DTOs.UserDTOs;
using StudentInsight.Entities;

namespace StudentInsight.Repositories.Interfaces
{
    public interface IUserRepository : IGeneralRepository<User>
    {
        Task<PagedResultDto<User>> GetAllAsync(UserFilterDto filterDto);
    }
}
