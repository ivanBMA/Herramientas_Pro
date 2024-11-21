using Microsoft.AspNetCore.Identity;

namespace Herramientas_Pro.Models // Usa el namespace adecuado
{
    public class ApplicationUser : IdentityUser
    {
        // Puedes agregar propiedades personalizadas aquí si lo necesitas
        // Ejemplo: public string FullName { get; set; }
        public string FullName { get; set; }
    }
}
