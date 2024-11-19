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
    public class FabricacionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FabricacionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Fabricacions
        public async Task<IActionResult> Index(string orden = "nombreAsc")
        {
            var fabricacion = _context.Fabricacion.AsQueryable();

            fabricacion = orden switch
            {
                "ProyectoAsc" => fabricacion.OrderBy(p => p.Proyecto),
                "ProyectoDesc" => fabricacion.OrderByDescending(p => p.Proyecto),

                "ClienteAsc" => fabricacion.OrderBy(p => p.Cliente),
                "ClienteDesc" => fabricacion.OrderByDescending(p => p.Cliente),

                "DiseñoAsc" => fabricacion.OrderBy(p => p.Diseño),
                "DiseñoDesc" => fabricacion.OrderByDescending(p => p.Diseño),

                "VidrioAsc" => fabricacion.OrderBy(p => p.Vidrio),
                "VidrioDesc" => fabricacion.OrderByDescending(p => p.Vidrio),

                "BarandaAsc" => fabricacion.OrderBy(p => p.Baranda),
                "BarandaDesc" => fabricacion.OrderByDescending(p => p.Baranda),

                "ZancasAsc" => fabricacion.OrderBy(p => p.Zancas),
                "ZancasDesc" => fabricacion.OrderByDescending(p => p.Zancas),

                "MontajesAsc" => fabricacion.OrderBy(p => p.Montajes),
                "MontajesDesc" => fabricacion.OrderByDescending(p => p.Montajes),

                "PlottersAsc" => fabricacion.OrderBy(p => p.Plotters),
                "PlottersDesc" => fabricacion.OrderByDescending(p => p.Plotters),

                "PeldañosAsc" => fabricacion.OrderBy(p => p.Peldaños),
                "PeldañosDesc" => fabricacion.OrderByDescending(p => p.Peldaños),

                "GuiaAsc" => fabricacion.OrderBy(p => p.Guia),
                "GuiaDesc" => fabricacion.OrderByDescending(p => p.Guia),

                "TornilleriaAsc" => fabricacion.OrderBy(p => p.Tornilleria),
                "TornilleriaDesc" => fabricacion.OrderByDescending(p => p.Tornilleria),
                _ => fabricacion
            };

            return View(fabricacion.ToList());
        }

        // GET: Fabricacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fabricacion = await _context.Fabricacion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fabricacion == null)
            {
                return NotFound();
            }

            return View(fabricacion);
        }

        // GET: Fabricacions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fabricacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Proyecto,Cliente,Diseño,Vidrio,Baranda,Zancas,Montajes,Plotters,Peldaños,Guia,Tornilleria")] Fabricacion fabricacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fabricacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fabricacion);
        }

        // GET: Fabricacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fabricacion = await _context.Fabricacion.FindAsync(id);
            if (fabricacion == null)
            {
                return NotFound();
            }
            return View(fabricacion);
        }

        // POST: Fabricacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Proyecto,Cliente,Diseño,Vidrio,Baranda,Zancas,Montajes,Plotters,Peldaños,Guia,Tornilleria")] Fabricacion fabricacion)
        {
            if (id != fabricacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fabricacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FabricacionExists(fabricacion.Id))
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
            return View(fabricacion);
        }

        // GET: Fabricacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fabricacion = await _context.Fabricacion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fabricacion == null)
            {
                return NotFound();
            }

            return View(fabricacion);
        }

        // POST: Fabricacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fabricacion = await _context.Fabricacion.FindAsync(id);
            if (fabricacion != null)
            {
                _context.Fabricacion.Remove(fabricacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FabricacionExists(int id)
        {
            return _context.Fabricacion.Any(e => e.Id == id);
        }
    }
}
