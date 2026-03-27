using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentInsight.DTOs.SubjectDTOs;
using StudentInsight.Services.Interfaces;

namespace StudentInsight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService service;

        public SubjectController(ISubjectService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] SubjectFilterDto filterDto)
        {
            var result = await service.GetAllAsync(filterDto);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var subject = await service.GetByIdAsync(id);
            return subject is null ? NotFound() : Ok(subject);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(SubjectCreateDto dto)
        {
            var subject = await service.CreateAsync(dto);
            return Ok(subject);
        }

        [HttpPost("bulk")]
        public async Task<IActionResult> CreateBulkAsync(List<SubjectCreateDto> dtos)
        {
            await service.CreateBulkAsync(dtos);
            return Ok($"All '{dtos.Count}' subjects have been inserted successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(SubjectUpdateDto dto)
        {
            var success = await service.UpdateAsync(dto);
            return success ? Ok("Subject has been updated successfully.") : NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            var success = await service.RemoveAsync(id);
            return success ? Ok("Subject has been removed successfully.") : NotFound();
        }
    }
}
