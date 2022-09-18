using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Educacion_backend.Models;

namespace Educacion_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColegiosApiController : ControllerBase
    {
        private readonly EducacionContext _context;

        public ColegiosApiController(EducacionContext context)
        {
            _context = context;
        }

        // GET: api/ColegiosApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colegio>>> GetColegios()
        {
            return await _context.Colegios.ToListAsync();
        }

        // GET: api/ColegiosApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Colegio>> GetColegio(decimal id)
        {
            var colegio = await _context.Colegios.FindAsync(id);

            if (colegio == null)
            {
                return NotFound();
            }

            return colegio;
        }

        // PUT: api/ColegiosApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColegio(decimal id, Colegio colegio)
        {
            if (id != colegio.Id)
            {
                return BadRequest();
            }

            _context.Entry(colegio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColegioExists(id))
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

        // POST: api/ColegiosApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Colegio>> PostColegio(Colegio colegio)
        {
            _context.Colegios.Add(colegio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColegio", new { id = colegio.Id }, colegio);
        }

        // DELETE: api/ColegiosApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColegio(decimal id)
        {
            var colegio = await _context.Colegios.FindAsync(id);
            if (colegio == null)
            {
                return NotFound();
            }

            _context.Colegios.Remove(colegio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColegioExists(decimal id)
        {
            return _context.Colegios.Any(e => e.Id == id);
        }
    }
}
