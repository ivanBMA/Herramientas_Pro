using Herramientas_Pro.Models;

namespace Herramientas_Pro.Services
{
    public class ProductosService
    {
        private readonly ApplicationDbContext _context;

        public ProductosService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CrearProducto(Productos producto)
        {
            try
            {
                _context.Productos.Add(producto);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Opcional: Registrar errores o manejarlos de otra forma
                Console.WriteLine($"Error al crear el producto: {ex.Message}");
                return false;
            }
        }

        public IEnumerable<Productos> ObtenerProductos()
        {
            return _context.Productos.ToList();
        }
    }
}
