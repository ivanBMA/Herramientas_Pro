using Herramientas_Pro.Models;
using Microsoft.EntityFrameworkCore;

namespace Herramientas_Pro.Services
{
    public class Entradas_SalidasService
    {
        private readonly ApplicationDbContext _context;

        public Entradas_SalidasService(ApplicationDbContext context)
        {
            _context = context;
        }


        public bool EditarEntradas_Salidas(Entradas_Salidas Entradas_SalidasNuevo, string Codigo_Producto)
        {
            try
            {
                var Entradas_Salidas = _context.Entradas_Salidas.Where(e => e.Codigo == Codigo_Producto).ToList();
                foreach (var entrada_salida in Entradas_Salidas)
                {
                    if (entrada_salida == null)
                    {
                        Console.WriteLine($"El producto con Codigo_Producto '{Codigo_Producto}' no se encontró en el entrada_salida.");
                        return false;
                    }

                    // Actualizar únicamente los valores que han cambiado
                    if (!string.IsNullOrEmpty(Entradas_SalidasNuevo.Producto) && Entradas_SalidasNuevo.Producto != entrada_salida.Producto)
                        entrada_salida.Producto = Entradas_SalidasNuevo.Producto;

                    if (!string.IsNullOrEmpty(Entradas_SalidasNuevo.Unidad) && Entradas_SalidasNuevo.Unidad != entrada_salida.Unidad)
                        entrada_salida.Unidad = Entradas_SalidasNuevo.Unidad;

                    _context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                // Opcional: Registrar errores o manejarlos de otra forma
                Console.WriteLine($"Error al editar el Entradas_Salidas: {ex.Message}");
                return false;
            }
        }


        public bool BorrarEntradas_Salidas(string Codigo_Producto)
        {
            try
            {
                var Entradas_Salidas = _context.Entradas_Salidas.Where(e => e.Codigo == Codigo_Producto).ToList();
                if (Entradas_Salidas != null)
                {
                    foreach (var entrada_salida in Entradas_Salidas)
                    {
                        _context.Entradas_Salidas.Remove(entrada_salida);
                        _context.SaveChanges();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                // Opcional: Registrar errores o manejarlos de otra forma
                Console.WriteLine($"Error al borrar el Entradas_Salidas: {ex.Message}");
                return false;
            }
        }

        public IEnumerable<Entradas_Salidas> ObtenerEntradas_Salidas()
        {
            return _context.Entradas_Salidas.ToList();
        }
    }
}
