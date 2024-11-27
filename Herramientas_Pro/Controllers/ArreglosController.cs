using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Herramientas_Pro.Models;
using Microsoft.AspNetCore.Authorization;

namespace Herramientas_Pro.Controllers
{
    [Authorize(Roles = "Admin,Manager,User")]

    public class ArreglosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArreglosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Arreglos
        public async Task<IActionResult> Index(string orden = "nombreAsc")
        {
            var arreglos = _context.Arreglos.AsQueryable();

            arreglos = orden switch
            {
                "ProyectoAsc" => arreglos.OrderBy(p => p.Proyecto),
                "ProyectoDesc" => arreglos.OrderByDescending(p => p.Proyecto),
                "ClienteAsc" => arreglos.OrderBy(p => p.Cliente),
                "ClienteDesc" => arreglos.OrderByDescending(p => p.Cliente),
                "DiseñoAsc" => arreglos.OrderBy(p => p.Diseño),
                "DiseñoDesc" => arreglos.OrderByDescending(p => p.Diseño),
                "VidriosAsc" => arreglos.OrderBy(p => p.Vidrios),
                "VidriosDesc" => arreglos.OrderByDescending(p => p.Vidrios),
                "BarandaAsc" => arreglos.OrderBy(p => p.Baranda),
                "BarandaDesc" => arreglos.OrderByDescending(p => p.Baranda),
                "ZancasAsc" => arreglos.OrderBy(p => p.Zancas),
                "ZancasDesc" => arreglos.OrderByDescending(p => p.Zancas),
                "MontajesAsc" => arreglos.OrderBy(p => p.Montajes),
                "MontajesDesc" => arreglos.OrderByDescending(p => p.Montajes),
                "PeldañosAsc" => arreglos.OrderBy(p => p.Peldaños),
                "PeldañosDesc" => arreglos.OrderByDescending(p => p.Peldaños),
                "GuiaAsc" => arreglos.OrderBy(p => p.Guia),
                "GuiaDesc" => arreglos.OrderByDescending(p => p.Guia),
                "TornilleriaAsc" => arreglos.OrderBy(p => p.Tornilleria),
                "TornilleriaDesc" => arreglos.OrderByDescending(p => p.Tornilleria),
                "OtrosAsc" => arreglos.OrderBy(p => p.Otros),
                "OtrosDesc" => arreglos.OrderByDescending(p => p.Otros),
                "EstadoAsc" => arreglos.OrderBy(p => p.Estado),
                "EstadoDesc" => arreglos.OrderByDescending(p => p.Estado),
                "CitaAsc" => arreglos.OrderBy(p => p.Cita),
                "CitaDesc" => arreglos.OrderByDescending(p => p.Cita),
                "FechaAsc" => arreglos.OrderBy(p => p.Fecha),
                "FechaDesc" => arreglos.OrderByDescending(p => p.Fecha),
                "ResponsableAsc" => arreglos.OrderBy(p => p.Responsable),
                "ResponsableDesc" => arreglos.OrderByDescending(p => p.Responsable),
                _ => arreglos
            };

            return View(arreglos.ToList());
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
        public async Task<IActionResult> Create([Bind("Id,Proyecto,Cliente,Diseño,Vidrios,Baranda,Zancas,Montajes,Peldaños,Guia,Tornilleria,Otros,Estado,Cita,Fecha,Responsable")] Arreglos arreglos)
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Proyecto,Cliente,Diseño,Vidrios,Baranda,Zancas,Montajes,Peldaños,Guia,Tornilleria,Otros,Estado,Cita,Fecha,Responsable")] Arreglos arreglos)
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
