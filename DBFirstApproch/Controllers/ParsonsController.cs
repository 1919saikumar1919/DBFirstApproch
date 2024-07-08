using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBFirstApproch.Models;

namespace DBFirstApproch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParsonsController : ControllerBase
    {
        private readonly HrmContext _context;

        public ParsonsController(HrmContext context)
        {
            _context = context;
        }

        // GET: api/Parsons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parson>>> GetParsons()
        {
            return await _context.Parsons.ToListAsync();
        }

        // GET: api/Parsons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parson>> GetParson(Guid id)
        {
            var parson = await _context.Parsons.FindAsync(id);

            if (parson == null)
            {
                return NotFound();
            }

            return parson;
        }

        // PUT: api/Parsons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParson(Guid id, Parson parson)
        {
            if (id != parson.ParsonId)
            {
                return BadRequest();
            }

            _context.Entry(parson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParsonExists(id))
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

        // POST: api/Parsons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Parson>> PostParson(Parson parson)
        {
            _context.Parsons.Add(parson);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ParsonExists(parson.ParsonId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetParson", new { id = parson.ParsonId }, parson);
        }

        // DELETE: api/Parsons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParson(Guid id)
        {
            var parson = await _context.Parsons.FindAsync(id);
            if (parson == null)
            {
                return NotFound();
            }

            _context.Parsons.Remove(parson);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParsonExists(Guid id)
        {
            return _context.Parsons.Any(e => e.ParsonId == id);
        }
    }
}
