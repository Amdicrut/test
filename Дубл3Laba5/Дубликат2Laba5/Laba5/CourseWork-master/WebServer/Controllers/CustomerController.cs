using Microsoft.AspNetCore.Mvc;
using WebServer.Data.DTOs;
using WebServer.Data.Models;
using WebServer.Data.Services;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _context;

        public CustomerController(CustomerService context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
            return await _context.GetCustomers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.GetCustomer(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> PutCustomer(int id, [FromBody] CustomerDTO customer)
        {
            var result = await _context.UpdateCustomer(id, customer);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer([FromBody] CustomerDTO customer)
        {
            var result = await _context.AddCustomer(customer);
            if (result == null)
            {
                BadRequest();
            }

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.DeleteCustomer(id);
            if (customer)
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}
