using Microsoft.AspNetCore.Mvc;
using StudentInsight.DTOs.StudentDTOs;
using StudentInsight.Exceptions;
using StudentInsight.Services.Interfaces;

namespace StudentInsight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService service;

        public StudentController(IStudentService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] StudentFilterDto filterDto)
        {
            var result = await service.GetAllAsync(filterDto);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var student = await service.GetByIdAsync(id);
            return student is null ? NotFound() : Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(StudentCreateDto dto)
        {
            try
            {
                var student = await service.CreateAsync(dto);
                return Ok(student);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("bulk")]
        public async Task<IActionResult> CreateBulkAsync(List<StudentCreateDto> dto)
        {
            await service.CreateBulkAsync(dto);
            return Ok($"All '{dto.Count}' students have been inserted successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(StudentUpdateDto dto)
        {
            var result = await service.UpdateAsync(dto);
            return result ? Ok("Student has been updated successfully.") : NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            var succeed = await service.RemoveAsync(id);
            return succeed ? Ok("Student has been removed successfully.") : NotFound();
        }
    }
}
