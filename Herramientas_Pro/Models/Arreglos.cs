using System.ComponentModel.DataAnnotations;

namespace Herramientas_Pro.Models
{
    public class Arreglos
    {
        [Key]
        public int Id { get; set; }  // Clave primaria recomendada
        public DateTime Fecha { get; set; }
        public String Responsable { get; set; }
    }
}
