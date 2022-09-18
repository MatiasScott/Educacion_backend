using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Educacion_backend.Models;

namespace Educacion_backend.Controllers
{
    public class CalificacionesController : Controller
    {
        private readonly EducacionContext _context;

        public CalificacionesController(EducacionContext context)
        {
            _context = context;
        }

        // GET: Calificaciones
        public async Task<IActionResult> Index()
        {
            var educacionContext = _context.Calificaciones.Include(c => c.IdColegioNavigation).Include(c => c.IdMateriaNavigation).Include(c => c.IdUsuarioNavigation);
            return View(await educacionContext.ToListAsync());
        }

        // GET: Calificaciones/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.Calificaciones == null)
            {
                return NotFound();
            }

            var calificacione = await _context.Calificaciones
                .Include(c => c.IdColegioNavigation)
                .Include(c => c.IdMateriaNavigation)
                .Include(c => c.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calificacione == null)
            {
                return NotFound();
            }

            return View(calificacione);
        }

        // GET: Calificaciones/Create
        public IActionResult Create()
        {
            ViewData["IdColegio"] = new SelectList(_context.Colegios, "Id", "Id");
            ViewData["IdMateria"] = new SelectList(_context.Materia, "Id", "Id");
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id");
            return View();
        }

        // POST: Calificaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdColegio,IdMateria,IdUsuario,Calificacion")] Calificacione calificacione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calificacione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdColegio"] = new SelectList(_context.Colegios, "Id", "Id", calificacione.IdColegio);
            ViewData["IdMateria"] = new SelectList(_context.Materia, "Id", "Id", calificacione.IdMateria);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id", calificacione.IdUsuario);
            return View(calificacione);
        }

        // GET: Calificaciones/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.Calificaciones == null)
            {
                return NotFound();
            }

            var calificacione = await _context.Calificaciones.FindAsync(id);
            if (calificacione == null)
            {
                return NotFound();
            }
            ViewData["IdColegio"] = new SelectList(_context.Colegios, "Id", "Id", calificacione.IdColegio);
            ViewData["IdMateria"] = new SelectList(_context.Materia, "Id", "Id", calificacione.IdMateria);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id", calificacione.IdUsuario);
            return View(calificacione);
        }

        // POST: Calificaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,IdColegio,IdMateria,IdUsuario,Calificacion")] Calificacione calificacione)
        {
            if (id != calificacione.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calificacione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalificacioneExists(calificacione.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdColegio"] = new SelectList(_context.Colegios, "Id", "Id", calificacione.IdColegio);
            ViewData["IdMateria"] = new SelectList(_context.Materia, "Id", "Id", calificacione.IdMateria);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id", calificacione.IdUsuario);
            return View(calificacione);
        }

        // GET: Calificaciones/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.Calificaciones == null)
            {
                return NotFound();
            }

            var calificacione = await _context.Calificaciones
                .Include(c => c.IdColegioNavigation)
                .Include(c => c.IdMateriaNavigation)
                .Include(c => c.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calificacione == null)
            {
                return NotFound();
            }

            return View(calificacione);
        }

        // POST: Calificaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.Calificaciones == null)
            {
                return Problem("Entity set 'EducacionContext.Calificaciones'  is null.");
            }
            var calificacione = await _context.Calificaciones.FindAsync(id);
            if (calificacione != null)
            {
                _context.Calificaciones.Remove(calificacione);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalificacioneExists(decimal id)
        {
          return _context.Calificaciones.Any(e => e.Id == id);
        }
    }
}
