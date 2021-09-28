using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiFacturas.Context;
using ApiFacturas.Models;

namespace ApiFacturas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DetalleController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Detalle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Detalle>>> GetDetalle()
        {
            return await _context.Detalle.ToListAsync();
        }

        // GET: api/Detalle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Detalle>> GetDetalle(int id)
        {
            var detalle = await _context.Detalle.FindAsync(id);

            if (detalle == null)
            {
                return NotFound();
            }

            return detalle;
        }

        // PUT: api/Detalle/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalle(int id, Detalle detalle)
        {
            if (id != detalle.DetalleId)
            {
                return BadRequest();
            }

            _context.Entry(detalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleExists(id))
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

        // POST: api/Detalle
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Detalle>> PostDetalle(Detalle detalle)
        {
            _context.Detalle.Add(detalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalle", new { id = detalle.DetalleId }, detalle);
        }

        // DELETE: api/Detalle/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Detalle>> DeleteDetalle(int id)
        {
            var detalle = await _context.Detalle.FindAsync(id);
            if (detalle == null)
            {
                return NotFound();
            }

            _context.Detalle.Remove(detalle);
            await _context.SaveChangesAsync();

            return detalle;
        }

        private bool DetalleExists(int id)
        {
            return _context.Detalle.Any(e => e.DetalleId == id);
        }
    }
}
