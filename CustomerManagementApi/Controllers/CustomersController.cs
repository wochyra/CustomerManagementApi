using AutoMapper;
using CustomerManagementApi.DTOs;
using CustomerManagementApi.Interfaces;
using CustomerManagementApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : Controller
    {
        private readonly ICustomerService _service;
        private readonly ILogger<CustomersController> _logger;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerService service, ILogger<CustomersController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Retrieving all customers.");
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            _logger.LogInformation("Retrieving customer with ID {Id}.", id);
            var customer = _service.GetById(id);
            return customer == null ? NotFound() : Ok(customer);
        }

        [HttpPost]
        public IActionResult Create(CreateCustomerRequest request)
        {
            var customer = _mapper.Map<Customer>(request);
            var created = _service.Create(customer);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateCustomerRequest request)
        {
            var customer = _mapper.Map<Customer>(request);
            var success = _service.Update(id, customer);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Deleting customer with ID {Id}.", id);
            return _service.Delete(id) ? NoContent() : NotFound();
        }
    }
}
