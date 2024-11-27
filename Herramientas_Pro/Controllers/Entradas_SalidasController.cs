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


    public class Entradas_SalidasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Entradas_SalidasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Entradas_Salidas
        public async Task<IActionResult> Index(string orden = "nombreAsc")
        {
            var entradas_salidas = _context.Entradas_Salidas.AsQueryable();

            entradas_salidas = orden switch
            {
                "CodigoAsc" => entradas_salidas.OrderBy(p => p.Codigo),
                "CodigoDesc" => entradas_salidas.OrderByDescending(p => p.Codigo),
                "ProductoAsc" => entradas_salidas.OrderBy(p => p.Producto),
                "ProductoDesc" => entradas_salidas.OrderByDescending(p => p.Producto),
                "CantidadAsc" => entradas_salidas.OrderBy(p => p.Cantidad),
                "CantidadDesc" => entradas_salidas.OrderByDescending(p => p.Cantidad),
                "UnidadAsc" => entradas_salidas.OrderBy(p => p.Unidad),
                "UnidadDesc" => entradas_salidas.OrderByDescending(p => p.Unidad),
                "FechaAsc" => entradas_salidas.OrderBy(p => p.Fecha),
                "FechaDesc" => entradas_salidas.OrderByDescending(p => p.Fecha),
                "FirmaAsc" => entradas_salidas.OrderBy(p => p.Firma),
                "FirmaDesc" => entradas_salidas.OrderByDescending(p => p.Firma),
                _ => entradas_salidas
            };

            return View(entradas_salidas.ToList());
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
            ViewBag.ShowDetails = false;
            ViewBag.existe = false;
            return View();
        }

        // POST: Entradas_Salidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Cantidad,Fecha,Firma")] Entradas_Salidas entradas_Salidas)
        {

            if (
                        (entradas_Salidas.Codigo != null && entradas_Salidas.Codigo is string) 
                    &&  (entradas_Salidas.Cantidad != null && entradas_Salidas.Cantidad is Double)
                    &&  (entradas_Salidas.Fecha != null && entradas_Salidas.Fecha is DateTime)
                    &&  (entradas_Salidas.Firma != null && entradas_Salidas.Firma is string)
                )
            {
                if (comprovarExistencia(entradas_Salidas))
                {
                    if (ValidadorCantidad(entradas_Salidas))
                    {
                        var inventario = _context.Inventario.FirstOrDefault(e => e.Codigo_Producto == entradas_Salidas.Codigo);
                        entradas_Salidas.Producto = inventario.Producto;
                        entradas_Salidas.Unidad = inventario.Unidad;

                        _context.Add(entradas_Salidas);
                        await _context.SaveChangesAsync();
                        ActualizarInventario(entradas_Salidas);
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.existe = false;
                        ViewBag.ShowDetails = true;
                        return View(entradas_Salidas);
                    }
                }
                else {
                    ViewBag.ShowDetails = false;
                    ViewBag.existe = true;
                    return View(entradas_Salidas);
                }
                
            }
            ViewBag.existe = false;
            ViewBag.ShowDetails = false;
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
            ViewBag.ShowDetails = false;
            return View(entradas_Salidas);
        }

        // POST: Entradas_Salidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Producto,Cantidad,Unidad,Fecha,Firma")] Entradas_Salidas entradas_Salidas)
        {
            if (id != entradas_Salidas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (ValidadorCantidad(entradas_Salidas))
                    {
                        _context.Update(entradas_Salidas);
                        await _context.SaveChangesAsync();

                        ActualizarInventario(entradas_Salidas);
                    }
                    else {
                        ViewBag.ShowDetails = true;
                    }
                    
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
                entradas_Salidas.Cantidad = entradas_Salidas.Cantidad * (-1);
                ActualizarInventario(entradas_Salidas);
                _context.Entradas_Salidas.Remove(entradas_Salidas);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool Entradas_SalidasExists(int id)
        {
            return _context.Entradas_Salidas.Any(e => e.Id == id);
        }

        private void ActualizarInventario(Entradas_Salidas entradaSalida)
        {
            // Buscar el producto en el inventario
            var inventario = _context.Inventario.FirstOrDefault(i => i.Codigo_Producto == entradaSalida.Codigo);

            if (inventario != null)
            {

                // Actualizar el campo Comprar
                inventario.stock = inventario.ActualizarStock(inventario, entradaSalida.Cantidad);
                inventario.Comprar = inventario.ActualizarComprar(inventario, entradaSalida.Cantidad);

                // Guardar los cambios en la base de datos
                _context.Inventario.Update(inventario);
                _context.SaveChanges();
            }
        }

        private Boolean ValidadorCantidad(Entradas_Salidas entradaSalida)
        {
            // Buscar el producto en el inventario
            var inventario = _context.Inventario.FirstOrDefault(i => i.Codigo_Producto == entradaSalida.Codigo);
            
                var resultado = (inventario.stock + entradaSalida.Cantidad);
                if (resultado >= 0)
                {
                    return true;
                }

            return false;
        }
        private Boolean comprovarExistencia(Entradas_Salidas entradaSalida)
        {
            // Buscar el producto en el inventario
            var inventario = _context.Inventario.FirstOrDefault(i => i.Codigo_Producto == entradaSalida.Codigo);

            if (inventario != null)
            {
                return true;
            }

            return false;
        }
    }
}
