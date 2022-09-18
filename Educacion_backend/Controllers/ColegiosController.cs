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
    public class ColegiosController : Controller
    {
        private readonly EducacionContext _context;

        public ColegiosController(EducacionContext context)
        {
            _context = context;
        }

        // GET: Colegios
        public async Task<IActionResult> Index()
        {
              return View(await _context.Colegios.ToListAsync());
        }

        // GET: Colegios/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.Colegios == null)
            {
                return NotFound();
            }

            var colegio = await _context.Colegios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (colegio == null)
            {
                return NotFound();
            }

            return View(colegio);
        }

        // GET: Colegios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Colegios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,TipoColegio")] Colegio colegio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colegio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(colegio);
        }

        // GET: Colegios/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.Colegios == null)
            {
                return NotFound();
            }

            var colegio = await _context.Colegios.FindAsync(id);
            if (colegio == null)
            {
                return NotFound();
            }
            return View(colegio);
        }

        // POST: Colegios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Nombre,TipoColegio")] Colegio colegio)
        {
            if (id != colegio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colegio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColegioExists(colegio.Id))
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
            return View(colegio);
        }

        // GET: Colegios/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.Colegios == null)
            {
                return NotFound();
            }

            var colegio = await _context.Colegios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (colegio == null)
            {
                return NotFound();
            }

            return View(colegio);
        }

        // POST: Colegios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.Colegios == null)
            {
                return Problem("Entity set 'EducacionContext.Colegios'  is null.");
            }
            var colegio = await _context.Colegios.FindAsync(id);
            if (colegio != null)
            {
                _context.Colegios.Remove(colegio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColegioExists(decimal id)
        {
          return _context.Colegios.Any(e => e.Id == id);
        }
    }
}
