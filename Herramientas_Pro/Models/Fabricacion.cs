using System.ComponentModel.DataAnnotations;

namespace Herramientas_Pro.Models
{
    public class Fabricacion
    {
        [Key]
        public int Id { get; set; }  // Clave primaria recomendada
        public String Proyecto { get; set; }
        public String Cliente { get; set; }
        public String Diseño { get; set; }
        public String Vidrio { get; set; }
        public String Baranda { get; set; }
        public String Zancas { get; set; }
        public String Montajes { get; set; }
        public String Plotters { get; set; }
        public String Peldaños { get; set; }
        public String Guia { get; set; }
        public String Tornilleria { get; set; }

    }
}
