using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Herramientas_Pro.Models;

namespace Herramientas_Pro.Controllers
{
    public class ArreglosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArreglosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Arreglos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Arreglos.ToListAsync());
        }

        // GET: Arreglos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arreglos = await _context.Arreglos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arreglos == null)
            {
                return NotFound();
            }

            return View(arreglos);
        }

        // GET: Arreglos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Arreglos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,Responsable")] Arreglos arreglos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arreglos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(arreglos);
        }

        // GET: Arreglos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arreglos = await _context.Arreglos.FindAsync(id);
            if (arreglos == null)
            {
                return NotFound();
            }
            return View(arreglos);
        }

        // POST: Arreglos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,Responsable")] Arreglos arreglos)
        {
            if (id != arreglos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arreglos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArreglosExists(arreglos.Id))
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
            return View(arreglos);
        }

        // GET: Arreglos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arreglos = await _context.Arreglos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arreglos == null)
            {
                return NotFound();
            }

            return View(arreglos);
        }

        // POST: Arreglos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var arreglos = await _context.Arreglos.FindAsync(id);
            if (arreglos != null)
            {
                _context.Arreglos.Remove(arreglos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArreglosExists(int id)
        {
            return _context.Arreglos.Any(e => e.Id == id);
        }
    }
}
