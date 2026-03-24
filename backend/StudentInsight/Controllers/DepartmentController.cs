using Microsoft.AspNetCore.Mvc;
using StudentInsight.DTOs.DepartmentDTOs;
using StudentInsight.Services.Interfaces;

namespace StudentInsight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService service;

        public DepartmentController(IDepartmentService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] DepartmentFilterDto filterDto)
        {
            var result = await service.GetAllAsync(filterDto);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var department = await service.GetByIdAsync(id);
            return department is null ? NotFound() : Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(DepartmentCreateDto dto)
        {
            var department = await service.CreateAsync(dto);
            return Ok(department);
        }

        [HttpPost("bulk")]
        public async Task<IActionResult> CreateBulkAsync(List<DepartmentCreateDto> dtos)
        {
            await service.CreateBulkAsync(dtos);
            return Ok($"All '{dtos.Count}' departments have been inserted successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(DepartmentUpdateDto dto)
        {
            var succeed = await service.UpdateAsync(dto);
            return succeed ? Ok("Department has been updated successfully.") : NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            var succeed = await service.RemoveAsync(id);
            return succeed ? Ok("Department has been removed successfully.") : NotFound();
        }
    }
}
