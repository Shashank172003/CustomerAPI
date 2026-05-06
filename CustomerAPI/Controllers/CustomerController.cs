using CustomerAPI.DTOs;
using CustomerAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
// this is my API controller
namespace CustomerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController (ICustomerService service)
        {
            _service = service;
        }

        [HttpPost]          
        public async Task<IActionResult> Create([FromBody] CreateCustomerDto dto)
        {
            var result = await _service.CreateCustomerAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllCustomerAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetCustomerByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
