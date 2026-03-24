using Microsoft.AspNetCore.Mvc;
using StudentInsight.DTOs.StudentExamLogsDTOs;
using StudentInsight.Exceptions;
using StudentInsight.Services.Interfaces;

namespace StudentInsight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentExamLogsController : ControllerBase
    {
        private readonly IStudentExamLogsService service;

        public StudentExamLogsController(IStudentExamLogsService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] StudentExamLogsFilterDto filterDto)
        {
            var result = await service.GetAllAsync(filterDto);
            return Ok(result);
        }

        [HttpGet("detailed")]
        public async Task<IActionResult> GetAllDetailedAsync([FromQuery] StudentExamLogsFilterDto filterDto)
        {
            try
            {
                var result = await service.GetAllDetailedAsync(filterDto);
                return Ok(result);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("detailed/{id:guid}")]
        public async Task<IActionResult> GetDetailedByIdAsync(Guid id)
        {
            try
            {
                var log = await service.GetDetailedByIdAsync(id);
                return log is null ? NotFound() : Ok(log);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var log = await service.GetByIdAsync(id);
            return log is null ? NotFound() : Ok(log);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(StudentExamLogsCreateDto dto)
        {
            try
            {
                var log = await service.CreateAsync(dto);
                return Ok(log);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("bulk")]
        public async Task<IActionResult> CreateBulkAsync(List<StudentExamLogsCreateDto> dtos)
        {
            await service.CreateBulkAsync(dtos);
            return Ok($"All '{dtos.Count}' logs has been inserted successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(StudentExamLogsUpdateDto dto)
        {
            try
            {
                var succeed = await service.UpdateAsync(dto);
                return succeed ? Ok("Log has been updated successfully.") : NotFound();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            var succeed = await service.RemoveAsync(id);
            return succeed ? Ok("Log has been removed successfully.") : NotFound();
        }
    }
}
