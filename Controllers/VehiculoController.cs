using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi4.Models;

namespace webapi4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        private readonly NeumaticosContext _context;

        public VehiculoController(NeumaticosContext context)
        {
            _context = context;
        }

        // GET: api/Vehiculo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SnVehiculo>>> GetSnVehiculo()
        {
            return await _context.SnVehiculo.ToListAsync();
        }

        // GET: api/Vehiculo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SnVehiculo>> GetSnVehiculo(string id)
        {
            var snVehiculo = await _context.SnVehiculo.FindAsync(id);

            if (snVehiculo == null)
            {
                return NotFound();
            }

            return snVehiculo;
        }

        // PUT: api/Vehiculo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSnVehiculo(string id, SnVehiculo snVehiculo)
        {
            if (id != snVehiculo.CodCia)
            {
                return BadRequest();
            }

            _context.Entry(snVehiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SnVehiculoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Vehiculo
        [HttpPost]
        public async Task<ActionResult<SnVehiculo>> PostSnVehiculo(SnVehiculo snVehiculo)
        {
            _context.SnVehiculo.Add(snVehiculo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SnVehiculoExists(snVehiculo.CodCia))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSnVehiculo", new { id = snVehiculo.CodCia }, snVehiculo);
        }

        // DELETE: api/Vehiculo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SnVehiculo>> DeleteSnVehiculo(string id)
        {
            var snVehiculo = await _context.SnVehiculo.FindAsync(id);
            if (snVehiculo == null)
            {
                return NotFound();
            }

            _context.SnVehiculo.Remove(snVehiculo);
            await _context.SaveChangesAsync();

            return snVehiculo;
        }

        private bool SnVehiculoExists(string id)
        {
            return _context.SnVehiculo.Any(e => e.CodCia == id);
        }
    }
}
