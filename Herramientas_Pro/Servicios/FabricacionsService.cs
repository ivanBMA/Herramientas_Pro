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
                var fabricacionExiste = _context.Fabricacion.FirstOrDefault(e => e.Proyecto == fabricacion.Proyecto);

                if (fabricacionExiste == null)
                {
                    _context.Fabricacion.Add(fabricacion);
                    _context.SaveChanges();
                }
                else {
                    // Actualizar únicamente los valores que han cambiado
                    if (!string.IsNullOrEmpty(fabricacion.Proyecto) && fabricacion.Proyecto != fabricacionExiste.Proyecto)
                        fabricacionExiste.Proyecto = fabricacion.Proyecto;

                    if (!string.IsNullOrEmpty(fabricacion.Cliente) && fabricacion.Cliente != fabricacionExiste.Cliente)
                        fabricacionExiste.Cliente = fabricacion.Cliente;
                    
                    if (!string.IsNullOrEmpty(fabricacion.Diseño) && fabricacion.Diseño != fabricacionExiste.Diseño)
                        fabricacionExiste.Diseño = fabricacion.Diseño; 

                    if (!string.IsNullOrEmpty(fabricacion.Vidrio) && fabricacion.Vidrio != fabricacionExiste.Vidrio)
                        fabricacionExiste.Vidrio = fabricacion.Vidrio; 

                    if (!string.IsNullOrEmpty(fabricacion.Baranda) && fabricacion.Baranda != fabricacionExiste.Baranda)
                        fabricacionExiste.Baranda = fabricacion.Baranda; 

                    if (!string.IsNullOrEmpty(fabricacion.Zancas) && fabricacion.Zancas != fabricacionExiste.Zancas)
                        fabricacionExiste.Zancas = fabricacion.Zancas; 

                    if (!string.IsNullOrEmpty(fabricacion.Montajes) && fabricacion.Montajes != fabricacionExiste.Montajes)
                        fabricacionExiste.Montajes = fabricacion.Montajes;
                    
                    if (!string.IsNullOrEmpty(fabricacion.Plotters) && fabricacion.Plotters != fabricacionExiste.Plotters)
                        fabricacionExiste.Plotters = fabricacion.Plotters; 

                    if (!string.IsNullOrEmpty(fabricacion.Peldaños) && fabricacion.Peldaños != fabricacionExiste.Peldaños)
                        fabricacionExiste.Peldaños = fabricacion.Peldaños;
                    
                    if (!string.IsNullOrEmpty(fabricacion.Guia) && fabricacion.Guia != fabricacionExiste.Guia)
                        fabricacionExiste.Guia = fabricacion.Guia; 

                    if (!string.IsNullOrEmpty(fabricacion.Tornilleria) && fabricacion.Tornilleria != fabricacionExiste.Tornilleria)
                        fabricacionExiste.Tornilleria = fabricacion.Tornilleria;


                    _context.Fabricacion.Update(fabricacionExiste);
                    _context.SaveChanges();
                }

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
