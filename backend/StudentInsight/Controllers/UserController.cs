using Microsoft.AspNetCore.Mvc;
using StudentInsight.DTOs.UserDTOs;
using StudentInsight.DTOs.UserDTOs.UserUpdateDtos;
using StudentInsight.Exceptions;
using StudentInsight.Services.Interfaces;

namespace StudentInsight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] UserFilterDto filterDto)
        {
            var result = await service.GetAllAsync(filterDto);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var user = await service.GetByIdAsync(id);
            return user is null ? NotFound() : Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(UserLoginDto dto)
        {
            try
            {
                var id = await service.LoginAsync(dto);
                return Ok(id);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(UserCreateDto dto)
        {
            try
            {
                var user = await service.CreateAsync(dto);
                return Ok(user);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(UserCreateDto dto)
        {
            try
            {
                var userId = await service.RegisterAsync(dto);
                return Ok(userId);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            var success = await service.RemoveAsync(id);
            return success ? Ok("User account has been removed successfully.") : NotFound();
        }

        [HttpPatch("update/profile-pic")]
        public async Task<IActionResult> UpdateProfilePiceAsync(UserUpdateProfilePicDto dto)
        {
            var success = await service.UpdateProfilePicAsync(dto);
            return success ? Ok("User's profile picture has been updated successfully.") : NotFound();
        }

        [HttpPatch("update/username")]
        public async Task<IActionResult> UpdateUsernameAsync(UserUpdateUsernameDto dto)
        {
            var success = await service.UpdateUsernameAsync(dto);
            return success ? Ok("User's username has been updated successfully.") : NotFound();
        }

        [HttpPatch("update/password")]
        public async Task<IActionResult> ChangePasswordAsync(UserChangePasswordDto dto)
        {
            try
            {
                var success = await service.ChangePasswordAsync(dto);
                return success ? Ok("User's password has been updated successfully.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
