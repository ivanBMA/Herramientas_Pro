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


    public class PedidosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PedidosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pedidos
        public async Task<IActionResult> Index(string orden = "nombreAsc")
        {
            var pedidos = _context.Pedidos.AsQueryable();

            pedidos = orden switch
            {
                "PresupuestosAsc" => pedidos.OrderBy(p => p.Presupuestos),
                "PresupuestosDesc" => pedidos.OrderByDescending(p => p.Presupuestos),
                "ClienteAsc" => pedidos.OrderBy(p => p.Cliente),
                "ClienteDesc" => pedidos.OrderByDescending(p => p.Cliente),
                "TipoAsc" => pedidos.OrderBy(p => p.Tipo),
                "TipoDesc" => pedidos.OrderByDescending(p => p.Tipo),
                "MedicionAsc" => pedidos.OrderBy(p => p.Medicion),
                "MedicionDesc" => pedidos.OrderByDescending(p => p.Medicion),
                "Nube_PuntosAsc" => pedidos.OrderBy(p => p.Nube_Puntos),
                "Nube_PuntosDesc" => pedidos.OrderByDescending(p => p.Nube_Puntos),
                "EstadoAsc" => pedidos.OrderBy(p => p.Estado),
                "EstadoDesc" => pedidos.OrderByDescending(p => p.Estado),
                "FechaAsc" => pedidos.OrderBy(p => p.Fecha),
                "FechaDesc" => pedidos.OrderByDescending(p => p.Fecha),
                "Diseño_InicialAsc" => pedidos.OrderBy(p => p.Diseño_Inicial),
                "Diseño_InicialDesc" => pedidos.OrderByDescending(p => p.Diseño_Inicial),
                "FimraAsc" => pedidos.OrderBy(p => p.Fimra),
                "FimraDesc" => pedidos.OrderByDescending(p => p.Fimra),
                "OtrosAsc" => pedidos.OrderBy(p => p.Otros),
                "OtrosDesc" => pedidos.OrderByDescending(p => p.Otros),
                "ResponsableAsc" => pedidos.OrderBy(p => p.Responsable),
                "ResponsableDesc" => pedidos.OrderByDescending(p => p.Responsable),
                _ => pedidos
            };

            return View(pedidos.ToList());
        }

        // GET: Pedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidos = await _context.Pedidos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedidos == null)
            {
                return NotFound();
            }

            return View(pedidos);
        }

        // GET: Pedidos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Presupuestos,Cliente,Tipo,Medicion,Nube_Puntos,Estado,Fecha,Diseño_Inicial,Fimra,Otros,Responsable")] Pedidos pedidos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pedidos);
        }

        // GET: Pedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidos = await _context.Pedidos.FindAsync(id);
            if (pedidos == null)
            {
                return NotFound();
            }
            return View(pedidos);
        }

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Presupuestos,Cliente,Tipo,Medicion,Nube_Puntos,Estado,Fecha,Diseño_Inicial,Fimra,Otros,Responsable")] Pedidos pedidos)
        {
            if (id != pedidos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidosExists(pedidos.Id))
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
            return View(pedidos);
        }

        // GET: Pedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidos = await _context.Pedidos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedidos == null)
            {
                return NotFound();
            }

            return View(pedidos);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedidos = await _context.Pedidos.FindAsync(id);
            if (pedidos != null)
            {
                _context.Pedidos.Remove(pedidos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidosExists(int id)
        {
            return _context.Pedidos.Any(e => e.Id == id);
        }
    }
}
