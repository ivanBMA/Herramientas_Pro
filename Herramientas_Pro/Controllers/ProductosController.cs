using Herramientas_Pro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Herramientas_Pro.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var productos = _context.Productos.ToList();
            return View(productos);
        }

        // GET: ProductosController1/Create
        public IActionResult CrearProducto()
        {
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearProducto(IFormCollection collection)
        {
            // Crea la instancia de Productos y asigna los valores manualmente desde collection
            Productos producto = new Productos()
            {
                Producto = collection["Producto"],
                Categoria = collection["Categoria"],
                Info = collection["Info"],
                Especificacion = collection["Especificacion"],
                Codigo_Producto = collection["Codigo_Producto"],
                Cantidad_Minima = Convert.ToDecimal(collection["Cantidad_Minima"]),
                Coste_Unidad = Convert.ToDecimal(collection["Coste_Unidad"]),
                Ubicacion = collection["Ubicacion"]
            };

            if (ModelState.IsValid)
            {
                _context.Productos.Add(producto);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(producto);
        }

        
        // GET: ProductosController1/Edit/5
        public IActionResult Editar(int id)
        {
            Productos protdutoAntiguo = _context.Productos.Find(id);
            return View(protdutoAntiguo);
        }

        // POST: ProductosController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, IFormCollection collection)
        {
            try
            {
                Productos productoNuevo = new Productos()
                {
                    Id = id,
                    Producto = collection["Producto"],
                    Categoria = collection["Categoria"],
                    Info = collection["Info"],
                    Especificacion = collection["Especificacion"],
                    Codigo_Producto = collection["Codigo_Producto"],
                    Cantidad_Minima = Convert.ToDecimal(collection["Cantidad_Minima"]),
                    Coste_Unidad = Convert.ToDecimal(collection["Coste_Unidad"]),
                    Ubicacion = collection["Ubicacion"]
                };
                _context.Productos.Update(productoNuevo);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductosController1/Delete/5
        public IActionResult Borrar(int id)
        {
            Productos protduto = _context.Productos.Find(id);
            _context.Productos.Remove(protduto);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
