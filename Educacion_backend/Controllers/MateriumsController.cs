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
    public class MateriumsController : Controller
    {
        private readonly EducacionContext _context;

        public MateriumsController(EducacionContext context)
        {
            _context = context;
        }

        // GET: Materiums
        public async Task<IActionResult> Index()
        {
            var educacionContext = _context.Materia.Include(m => m.IdColegioNavigation);
            return View(await educacionContext.ToListAsync());
        }

        // GET: Materiums/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.Materia == null)
            {
                return NotFound();
            }

            var materium = await _context.Materia
                .Include(m => m.IdColegioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materium == null)
            {
                return NotFound();
            }

            return View(materium);
        }

        // GET: Materiums/Create
        public IActionResult Create()
        {
            ViewData["IdColegio"] = new SelectList(_context.Colegios, "Id", "Id");
            return View();
        }

        // POST: Materiums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdColegio,Nombre,Area,NumeroEstudiantes,DocenteAsignado,Curso,Paralelo")] Materium materium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdColegio"] = new SelectList(_context.Colegios, "Id", "Id", materium.IdColegio);
            return View(materium);
        }

        // GET: Materiums/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.Materia == null)
            {
                return NotFound();
            }

            var materium = await _context.Materia.FindAsync(id);
            if (materium == null)
            {
                return NotFound();
            }
            ViewData["IdColegio"] = new SelectList(_context.Colegios, "Id", "Id", materium.IdColegio);
            return View(materium);
        }

        // POST: Materiums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,IdColegio,Nombre,Area,NumeroEstudiantes,DocenteAsignado,Curso,Paralelo")] Materium materium)
        {
            if (id != materium.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriumExists(materium.Id))
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
            ViewData["IdColegio"] = new SelectList(_context.Colegios, "Id", "Id", materium.IdColegio);
            return View(materium);
        }

        // GET: Materiums/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.Materia == null)
            {
                return NotFound();
            }

            var materium = await _context.Materia
                .Include(m => m.IdColegioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materium == null)
            {
                return NotFound();
            }

            return View(materium);
        }

        // POST: Materiums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.Materia == null)
            {
                return Problem("Entity set 'EducacionContext.Materia'  is null.");
            }
            var materium = await _context.Materia.FindAsync(id);
            if (materium != null)
            {
                _context.Materia.Remove(materium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MateriumExists(decimal id)
        {
          return _context.Materia.Any(e => e.Id == id);
        }
    }
}
