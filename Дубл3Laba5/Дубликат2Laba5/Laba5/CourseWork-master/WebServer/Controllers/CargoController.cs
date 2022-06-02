using Microsoft.AspNetCore.Mvc;
using WebServer.Data.DTOs;
using WebServer.Data.Models;
using WebServer.Data.Services;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CargoController : ControllerBase
    {
        private readonly CargoService _context;

        public CargoController(CargoService context)
        {
            _context = context;
            
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cargo>>> GetCargo()
        {
            return await _context.GetCargos();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cargo>> GetCargo(int id)
        {
            var cargo = await _context.GetCargo(id);

            if (cargo == null)
            {
                return NotFound();
            }

            return cargo;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Cargo>> PutCargo(int id, [FromBody] CargoDTO cargo)
        {
            var result = await _context.UpdateCargo(cargo);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Cargo>> PostCargo([FromBody] CargoDTO cargo)
        {
            var result = await _context.AddCargo(cargo);
            if (result == null)
            {
                BadRequest();
            }

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargo(int id)
        {
            var cargo = await _context.DeleteCargo(id);
            if (cargo)
            {
                return Ok();
            }
            return BadRequest();
        }
        
    }
}
