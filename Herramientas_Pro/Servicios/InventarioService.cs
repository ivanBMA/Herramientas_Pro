using Herramientas_Pro.Models;
using Microsoft.EntityFrameworkCore;

namespace Herramientas_Pro.Services
{
    public class InventarioService
    {
        private readonly ApplicationDbContext _context;

        public InventarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CrearInventario(Inventario inventario)
        {
            try
            {
                _context.Inventario.Add(inventario);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Opcional: Registrar errores o manejarlos de otra forma
                Console.WriteLine($"Error al crear el inventario: {ex.Message}");
                return false;
            }
        }

        public bool EditarInventario(Inventario inventarioNuevo, String Producto)
        {
            try
            {
                Inventario inventario = _context.Inventario.FirstOrDefault(e => e.Producto == Producto);

                inventario.Producto = inventarioNuevo.Producto;
                inventario.Codigo_Producto = inventarioNuevo.Codigo_Producto;
                inventario.Unidad = inventarioNuevo.Unidad;
                inventario.Cantidad_Minima = inventarioNuevo.Cantidad_Minima;
                inventario.Unidad2 = inventarioNuevo.Unidad2;

                _context.Inventario.Update(inventario);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Opcional: Registrar errores o manejarlos de otra forma
                Console.WriteLine($"Error al editar el inventario: {ex.Message}");
                return false;
            }
        }

        public bool BorrarInventario(Inventario inventario)
        {
            try
            {
                _context.Inventario.Remove(inventario);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Opcional: Registrar errores o manejarlos de otra forma
                Console.WriteLine($"Error al borrar el inventario: {ex.Message}");
                return false;
            }
        }

        public IEnumerable<Inventario> ObtenerInventario()
        {
            return _context.Inventario.ToList();
        }
    }
}
