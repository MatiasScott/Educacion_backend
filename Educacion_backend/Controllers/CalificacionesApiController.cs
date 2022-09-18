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
    public class CalificacionesApiController : ControllerBase
    {
        private readonly EducacionContext _context;

        public CalificacionesApiController(EducacionContext context)
        {
            _context = context;
        }

        // GET: api/CalificacionesApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calificacione>>> GetCalificaciones()
        {
            return await _context.Calificaciones.ToListAsync();
        }

        // GET: api/CalificacionesApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Calificacione>> GetCalificacione(decimal id)
        {
            var calificacione = await _context.Calificaciones.FindAsync(id);

            if (calificacione == null)
            {
                return NotFound();
            }

            return calificacione;
        }

        // PUT: api/CalificacionesApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalificacione(decimal id, Calificacione calificacione)
        {
            if (id != calificacione.Id)
            {
                return BadRequest();
            }

            _context.Entry(calificacione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalificacioneExists(id))
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

        // POST: api/CalificacionesApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Calificacione>> PostCalificacione(Calificacione calificacione)
        {
            _context.Calificaciones.Add(calificacione);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalificacione", new { id = calificacione.Id }, calificacione);
        }

        // DELETE: api/CalificacionesApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalificacione(decimal id)
        {
            var calificacione = await _context.Calificaciones.FindAsync(id);
            if (calificacione == null)
            {
                return NotFound();
            }

            _context.Calificaciones.Remove(calificacione);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalificacioneExists(decimal id)
        {
            return _context.Calificaciones.Any(e => e.Id == id);
        }
    }
}
