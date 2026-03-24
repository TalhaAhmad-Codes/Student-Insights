using Microsoft.AspNetCore.Mvc;
using StudentInsight.DTOs.ExamDTOs;
using StudentInsight.Services.Interfaces;

namespace StudentInsight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService service;

        public ExamController(IExamService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] ExamFilterDto filterDto)
        {
            var result = await service.GetAllAsync(filterDto);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var exam = await service.GetByIdAsync(id);
            return exam is null ? NotFound() : Ok(exam);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ExamCreateDto dto)
        {
            var exam = await service.CreateAsync(dto);
            return Ok(exam);
        }

        [HttpPost("bulk")]
        public async Task<IActionResult> CreateBulkAsync(List<ExamCreateDto> dtos)
        {
            await service.CreateBulkAsync(dtos);
            return Ok($"All '{dtos.Count}' exams have been inserted successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(ExamUpdateDto dto)
        {
            var succeed = await service.UpdateAsync(dto);
            return succeed ? Ok("Exam has been updated successfully.") : NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            var succeed = await service.RemoveAsync(id);
            return succeed ? Ok("Exam has been removed successfully.") : NotFound();
        }
    }
}
