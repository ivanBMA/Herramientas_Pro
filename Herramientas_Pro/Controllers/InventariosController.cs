﻿using System;
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


    public class InventariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InventariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Inventarios
        public async Task<IActionResult> Index(string orden = "nombreAsc")
        {
            var inventario = _context.Inventario.AsQueryable();
            inventario = orden switch
            {
                "ProductoAsc" => inventario.OrderBy(p => p.Producto),
                "ProductoDesc" => inventario.OrderByDescending(p => p.Producto),
                "Codigo_ProductoAsc" => inventario.OrderBy(p => p.Codigo_Producto),
                "Codigo_ProductoDesc" => inventario.OrderByDescending(p => p.Codigo_Producto),
                "stockAsc" => inventario.OrderBy(p => p.stock),
                "stockDesc" => inventario.OrderByDescending(p => p.stock),
                "UnidadAsc" => inventario.OrderBy(p => p.Unidad),
                "UnidadDesc" => inventario.OrderByDescending(p => p.Unidad),
                "Cantidad_MinimaAsc" => inventario.OrderBy(p => p.Cantidad_Minima),
                "Cantidad_MinimaDesc" => inventario.OrderByDescending(p => p.Cantidad_Minima),
                "Unidad2Asc" => inventario.OrderBy(p => p.Unidad2),
                "Unidad2Desc" => inventario.OrderByDescending(p => p.Unidad2),
                "ComprarAsc" => inventario.OrderBy(p => p.Comprar),
                "ComprarDesc" => inventario.OrderByDescending(p => p.Comprar),
                _ => inventario
            };

            return View(inventario.ToList());
        }

        // GET: Inventarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventario = await _context.Inventario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventario == null)
            {
                return NotFound();
            }

            return View(inventario);
        }

        // GET: Inventarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inventarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Producto,Codigo_Producto,stock,Unidad,Cantidad_Minima,Unidad2,Comprar")] Inventario inventario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventario);
        }

        // GET: Inventarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventario = await _context.Inventario.FindAsync(id);
            if (inventario == null)
            {
                return NotFound();
            }
            return View(inventario);
        }

        // POST: Inventarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Producto,Codigo_Producto,stock,Unidad,Cantidad_Minima,Unidad2,Comprar")] Inventario inventario)
        {
            if (id != inventario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventarioExists(inventario.Id))
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
            return View(inventario);
        }

        // GET: Inventarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventario = await _context.Inventario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventario == null)
            {
                return NotFound();
            }

            return View(inventario);
        }

        // POST: Inventarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventario = await _context.Inventario.FindAsync(id);
            if (inventario != null)
            {
                _context.Inventario.Remove(inventario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventarioExists(int id)
        {
            return _context.Inventario.Any(e => e.Id == id);
        }
    }
}
