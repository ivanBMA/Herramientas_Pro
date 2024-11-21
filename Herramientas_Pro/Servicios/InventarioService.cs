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
                //-->
                inventario.Comprar = inventario.ActualizarComprar(inventario, 0);

                _context.Inventario.Update(inventario);
                _context.SaveChanges();
                //-->
                return true;
            }
            catch (Exception ex)
            {
                // Opcional: Registrar errores o manejarlos de otra forma
                Console.WriteLine($"Error al crear el inventario: {ex.Message}");
                return false;
            }
        }

        public bool EditarInventario(Inventario inventarioNuevo, string Codigo_Producto)
        {
            try
            {
                var inventario = _context.Inventario.FirstOrDefault(e => e.Codigo_Producto == Codigo_Producto);
                if (inventario == null)
                {
                    Console.WriteLine($"El producto con Codigo_Producto '{Codigo_Producto}' no se encontró en el inventario.");
                    return false;
                }

                // Actualizar únicamente los valores que han cambiado
                if (!string.IsNullOrEmpty(inventarioNuevo.Producto) && inventarioNuevo.Producto != inventario.Producto)
                    inventario.Producto = inventarioNuevo.Producto;

                if (!string.IsNullOrEmpty(inventarioNuevo.Codigo_Producto) && inventarioNuevo.Codigo_Producto != inventario.Codigo_Producto)
                    inventario.Codigo_Producto = inventarioNuevo.Codigo_Producto;

                if (!string.IsNullOrEmpty(inventarioNuevo.Unidad) && inventarioNuevo.Unidad != inventario.Unidad)
                    inventario.Unidad = inventarioNuevo.Unidad;

                if (inventarioNuevo.Cantidad_Minima > 0 && inventarioNuevo.Cantidad_Minima != inventario.Cantidad_Minima)
                    inventario.Cantidad_Minima = inventarioNuevo.Cantidad_Minima;

                if (!string.IsNullOrEmpty(inventarioNuevo.Unidad2) && inventarioNuevo.Unidad2 != inventario.Unidad2)
                    inventario.Unidad2 = inventarioNuevo.Unidad2;

                _context.SaveChanges();
                //-->
                inventario.Comprar = inventario.ActualizarComprar(inventario, 0);

                _context.Inventario.Update(inventario);
                _context.SaveChanges();
                //-->
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
