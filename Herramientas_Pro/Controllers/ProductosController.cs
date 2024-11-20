using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Herramientas_Pro.Models;
using Herramientas_Pro.Services;

namespace Herramientas_Pro.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ProductosService _productosService;
        private readonly ILogger<ExcelsController> _logger;
        private readonly InventarioService _inventarioService;


        public ProductosController(ApplicationDbContext context, ProductosService productosService, InventarioService inventarioService)
        {
            _context = context;
            _productosService = productosService ?? throw new ArgumentNullException(nameof(productosService));
            _inventarioService = inventarioService ?? throw new ArgumentNullException(nameof(inventarioService));
        }

        // GET: Productos
        public async Task<IActionResult> Index(string orden = "nombreAsc")
        {
            var productos = _context.Productos.AsQueryable();

            productos = orden switch
            {
                "ProductoAsc" => productos.OrderBy(p => p.Producto),
                "ProductoDesc" => productos.OrderByDescending(p => p.Producto),

                "CategoriaAsc" => productos.OrderBy(p => p.Categoria),
                "CategoriaDesc" => productos.OrderByDescending(p => p.Categoria),

                "Codigo_ProductoAsc" => productos.OrderBy(p => p.Codigo_Producto),
                "Codigo_ProductoDesc" => productos.OrderByDescending(p => p.Codigo_Producto),

                "Cantidad_MinimaAsc" => productos.OrderBy(p => p.Cantidad_Minima),
                "Cantidad_MinimaDesc" => productos.OrderByDescending(p => p.Cantidad_Minima),

                "UnidadAsc" => productos.OrderBy(p => p.Unidad),
                "UnidadDesc" => productos.OrderByDescending(p => p.Unidad),

                "Coste_UnidadAsc" => productos.OrderBy(p => p.Coste_Unidad),
                "Coste_UnidadDesc" => productos.OrderByDescending(p => p.Coste_Unidad),

                "UbicacionAsc" => productos.OrderBy(p => p.Ubicacion),
                "UbicacionDesc" => productos.OrderByDescending(p => p.Ubicacion),
                _ => productos
            };

            return View(productos.ToList());
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Producto,Categoria,Codigo_Producto,Cantidad_Minima,Unidad,Coste_Unidad,Ubicacion")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productos);
                await _context.SaveChangesAsync();

                Inventario inventario = new() {
                    Producto        = productos.Producto,
                    Codigo_Producto = productos.Codigo_Producto,
                    stock           = 0,
                    Unidad          = productos.Unidad,
                    Cantidad_Minima = (double)productos.Cantidad_Minima,
                    Unidad2         = productos.Unidad,
                    Comprar         = (double)productos.Cantidad_Minima
                };

                _inventarioService.CrearInventario(inventario);

                return RedirectToAction(nameof(Index));
            }
            return View(productos);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos.FindAsync(id);
            if (productos == null)
            {
                return NotFound();
            }
            return View(productos);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Producto,Categoria,Codigo_Producto,Cantidad_Minima,Unidad,Coste_Unidad,Ubicacion")] Productos productos)
        {
            if (id != productos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var productosAntiguo = _context.Productos.FirstOrDefault(e => e.Id == productos.Id);
                    _context.Update(productos);
                    await _context.SaveChangesAsync();

                    /*
                    Inventario inventario = new()
                    {
                        Producto = productos.Producto,
                        Codigo_Producto = productos.Codigo_Producto,
                        stock = 0,
                        Unidad = productos.Unidad,
                        Cantidad_Minima = (double)productos.Cantidad_Minima,
                        Unidad2 = productos.Unidad,
                        Comprar = (double)productos.Cantidad_Minima
                    };

                    _inventarioService.EditarInventario(inventario, productosAntiguo!.Producto);
                    */
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductosExists(productos.Id))
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
            return View(productos);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productos = await _context.Productos.FindAsync(id);
            if (productos != null)
            {
                _context.Productos.Remove(productos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductosExists(int id)
        {
            return _context.Productos.Any(e => e.Id == id);
        }

        public bool crearProducto(Productos productos) {

            _context.Add(productos);
            _context.SaveChangesAsync();

            return true;
        }
    }
}
