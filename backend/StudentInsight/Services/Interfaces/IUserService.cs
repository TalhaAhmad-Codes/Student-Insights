using StudentInsight.DTOs.UserDTOs;
using StudentInsight.DTOs.UserDTOs.UserUpdateDtos;

namespace StudentInsight.Services.Interfaces
{
    public interface IUserService : IBaseService<UserResponseDto, UserCreateDto, UserFilterDto>
    {
        // PATCH Services
        Task<bool> UpdateProfilePicAsync(UserUpdateProfilePicDto dto);
        Task<bool> UpdateUsernameAsync(UserUpdateUsernameDto dto);
        Task<bool> ChangePasswordAsync(UserChangePasswordDto dto);
        
        // Account Login/Register Services
        Task<AuthResponseDto> LoginAsync(UserLoginDto dto);
        Task<AuthResponseDto> RegisterAsync(UserCreateDto dto);
    }
}
