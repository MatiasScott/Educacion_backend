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
    public class MateriumsApiController : ControllerBase
    {
        private readonly EducacionContext _context;

        public MateriumsApiController(EducacionContext context)
        {
            _context = context;
        }

        // GET: api/MateriumsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Materium>>> GetMateria()
        {
            return await _context.Materia.ToListAsync();
        }

        // GET: api/MateriumsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Materium>> GetMaterium(decimal id)
        {
            var materium = await _context.Materia.FindAsync(id);

            if (materium == null)
            {
                return NotFound();
            }

            return materium;
        }

        // PUT: api/MateriumsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterium(decimal id, Materium materium)
        {
            if (id != materium.Id)
            {
                return BadRequest();
            }

            _context.Entry(materium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MateriumExists(id))
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

        // POST: api/MateriumsApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Materium>> PostMaterium(Materium materium)
        {
            _context.Materia.Add(materium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterium", new { id = materium.Id }, materium);
        }

        // DELETE: api/MateriumsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterium(decimal id)
        {
            var materium = await _context.Materia.FindAsync(id);
            if (materium == null)
            {
                return NotFound();
            }

            _context.Materia.Remove(materium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MateriumExists(decimal id)
        {
            return _context.Materia.Any(e => e.Id == id);
        }
    }
}
