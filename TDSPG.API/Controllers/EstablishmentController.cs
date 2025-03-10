using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TDSPG.API.Domain.Entity;
using TDSPG.API.Infrastructure.Context;

namespace TDSPG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstablishmentController : ControllerBase
    {
        private readonly TDSPGContext _context;

        public EstablishmentController(TDSPGContext context)
        {
            _context = context;
        }

        // GET: api/Establishment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Establishment>>> GetEstablishments()
        {
            return await _context.Establishments.ToListAsync();
        }

        // GET: api/Establishment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Establishment>> GetEstablishment(Guid id)
        {
            var establishment = await _context.Establishments.FindAsync(id);

            if (establishment == null)
            {
                return NotFound();
            }

            return establishment;
        }

        // PUT: api/Establishment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstablishment(Guid id, Establishment establishment)
        {
            if (id != establishment.EstablishmentId)
            {
                return BadRequest();
            }

            _context.Entry(establishment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstablishmentExists(id))
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

        // POST: api/Establishment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Establishment>> PostEstablishment(Establishment establishment)
        {
            _context.Establishments.Add(establishment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstablishment", new { id = establishment.EstablishmentId }, establishment);
        }

        // DELETE: api/Establishment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstablishment(Guid id)
        {
            var establishment = await _context.Establishments.FindAsync(id);
            if (establishment == null)
            {
                return NotFound();
            }

            _context.Establishments.Remove(establishment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstablishmentExists(Guid id)
        {
            return _context.Establishments.Any(e => e.EstablishmentId == id);
        }
    }
}
