using StudentInsight.DTOs.Common;
using StudentInsight.DTOs.UserDTOs;
using StudentInsight.DTOs.UserDTOs.UserUpdateDtos;
using StudentInsight.Exceptions;
using StudentInsight.Helpers.Utils;
using StudentInsight.Mappers;
using StudentInsight.Repositories.Interfaces;
using StudentInsight.Services.Interfaces;

namespace StudentInsight.Services.Implementation
{
    public sealed class UserService : IUserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        private async Task<bool> DoesEmailExist(string email)
        {
            var user = await repository.GetByEmailAsync(email);
            return user is null ? false : true;
        }

        public async Task<bool> ChangePasswordAsync(UserChangePasswordDto dto)
        {
            var user = await repository.GetByIdAsync(dto.Id);

            // User not found!
            if (user is null)
                return false;

            // Password mismatch
            if (!PasswordHasher.Verify(dto.OldPassword, user.PasswordHash))
                return false;

            // Update password
            user.PasswordHash = PasswordHasher.Hash(dto.NewPassword);
            await repository.UpdateAsync(user);
            return true;
        }

        public async Task<UserResponseDto> CreateAsync(UserCreateDto dto)
        {
            if (await DoesEmailExist(dto.Email))
            {
                throw new DomainException("Email is already registered. Try Login!");
            }

            var user = UserMapper.ToEntity(dto);

            await repository.AddAsync(user);
            return UserMapper.ToDto(user);
        }

        public async Task<PagedResultDto<UserResponseDto>> GetAllAsync(UserFilterDto filterDto)
        {
            var result = await repository.GetAllAsync(filterDto);
            return new PagedResultDto<UserResponseDto>
            {
                Items = result.Items.Select(UserMapper.ToDto).ToList(),
                TotalCount = result.TotalCount
            };
        }

        public async Task<UserResponseDto?> GetByIdAsync(Guid id)
        {
            var user = await repository.GetByIdAsync(id);

            return user is null ? null : UserMapper.ToDto(user);
        }

        public async Task<Guid> LoginAsync(UserLoginDto dto)
        {
            var user = await repository.GetByEmailAsync(dto.Email);

            // Not found - User is not registered
            if (user is null)
            {
                throw new DomainException("Email is not registered.");
            }

            // Credentials mismatch
            if (!PasswordHasher.Verify(dto.Password, user.PasswordHash))
            {
                throw new DomainException("Wrong password! Try again.");
            }

            return user.Id;
        }

        public async Task<Guid> RegisterAsync(UserCreateDto dto)
        {
            var user = await CreateAsync(dto);
            return user.Id;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var user = await repository.GetByIdAsync(id);

            // Not Found
            if (user is null)
                return false;

            await repository.RemoveAsync(user);
            return true;
        }

        public async Task<bool> UpdateProfilePicAsync(UserUpdateProfilePicDto dto)
        {
            var user = await repository.GetByIdAsync(dto.Id);

            // Not Found
            if (user is null)
                return false;

            user.ProfilePic = dto.ProfilePic;
            await repository.UpdateAsync(user);
            return true;
        }

        public async Task<bool> UpdateUsernameAsync(UserUpdateUsernameDto dto)
        {
            var user = await repository.GetByIdAsync(dto.Id);

            // Not Found
            if (user is null)
                return false;

            user.Username = dto.Username;
            await repository.UpdateAsync(user);
            return true;
        }

        public async Task CreateBulkAsync(List<UserCreateDto> dtos)
        {
            await repository.AddBulkAsync(dtos.Select(UserMapper.ToEntity).ToList());
        }
    }
}
