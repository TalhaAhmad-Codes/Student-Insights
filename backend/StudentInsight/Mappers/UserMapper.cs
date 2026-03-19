using StudentInsight.DTOs.UserDTOs;
using StudentInsight.Entities;
using StudentInsight.Helpers.Utils;

namespace StudentInsight.Mappers
{
    public static class UserMapper
    {
        public static UserResponseDto ToDto(User user)
            => new()
            {
                Id = user.Id,
                ProfilePic = user.ProfilePic,
                Username = user.Username,
                Email = user.Email,
                CreatedAt = user.CreatedAt
            };

        public static AuthResponseDto ToAuthDto(User user)
            => new()
            {
                Id = user.Id
            };

        public static User ToEntity(UserCreateDto dto)
            => new()
            {
                ProfilePic = dto.ProfilePic,
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = PasswordHasher.Hash(dto.Password)
            };
    }
}
