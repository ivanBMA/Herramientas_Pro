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
    public class Entradas_SalidasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Entradas_SalidasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Entradas_Salidas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Entradas_Salidas.ToListAsync());
        }

        // GET: Entradas_Salidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entradas_Salidas = await _context.Entradas_Salidas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entradas_Salidas == null)
            {
                return NotFound();
            }

            return View(entradas_Salidas);
        }

        // GET: Entradas_Salidas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Entradas_Salidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Proyecto,Cliente,Diseño,Vidrios,Baranda,Zanca,Montajes,Plotters,Peldaños,Guia,Tornilleria")] Entradas_Salidas entradas_Salidas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entradas_Salidas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entradas_Salidas);
        }

        // GET: Entradas_Salidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entradas_Salidas = await _context.Entradas_Salidas.FindAsync(id);
            if (entradas_Salidas == null)
            {
                return NotFound();
            }
            return View(entradas_Salidas);
        }

        // POST: Entradas_Salidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Proyecto,Cliente,Diseño,Vidrios,Baranda,Zanca,Montajes,Plotters,Peldaños,Guia,Tornilleria")] Entradas_Salidas entradas_Salidas)
        {
            if (id != entradas_Salidas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entradas_Salidas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Entradas_SalidasExists(entradas_Salidas.Id))
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
            return View(entradas_Salidas);
        }

        // GET: Entradas_Salidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entradas_Salidas = await _context.Entradas_Salidas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entradas_Salidas == null)
            {
                return NotFound();
            }

            return View(entradas_Salidas);
        }

        // POST: Entradas_Salidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entradas_Salidas = await _context.Entradas_Salidas.FindAsync(id);
            if (entradas_Salidas != null)
            {
                _context.Entradas_Salidas.Remove(entradas_Salidas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Entradas_SalidasExists(int id)
        {
            return _context.Entradas_Salidas.Any(e => e.Id == id);
        }
    }
}
