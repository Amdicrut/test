using Microsoft.AspNetCore.Mvc;
using WebServer.Data.DTOs;
using WebServer.Data.Models;
using WebServer.Data.Services;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TransportController : ControllerBase
    {
        private readonly TransportService _context;

        public TransportController(TransportService context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transport>>> GetTransport()
        {
            return await _context.GetTransports();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transport>> GetTransport(int id)
        {
            var transport = await _context.GetTransport(id);

            if (transport == null)
            {
                return NotFound();
            }

            return transport;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Transport>> PutTransport(int id, [FromBody] TransportDTO transport)
        {
            var result = await _context.UpdateTransport(transport);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Transport>> PostTransport([FromBody] TransportDTO transport)
        {
            var result = await _context.AddTransport(transport);
            if (result == null)
            {
                BadRequest();
            }

            return Ok(result);
        }
        [HttpDelete("{id}")] 
        public async Task<IActionResult> DeleteTransport(int id)
        {
            var transport = await _context.DeleteTransport(id);
            if (transport)
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}
