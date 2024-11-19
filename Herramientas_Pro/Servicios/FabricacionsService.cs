using Herramientas_Pro.Models;

namespace Herramientas_Pro.Services
{
    public class FabricacionsService
    {
        private readonly ApplicationDbContext _context;

        public FabricacionsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CrearFabricacion(Fabricacion fabricacion)
        {
            try
            {
                _context.Fabricacion.Add(fabricacion);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Opcional: Registrar errores o manejarlos de otra forma
                Console.WriteLine($"Error al crear el fabricacion: {ex.Message}");
                return false;
            }
        }

        public IEnumerable<Fabricacion> ObtenerFabricaciones()
        {
            return _context.Fabricacion.ToList();
        }
    }
}
