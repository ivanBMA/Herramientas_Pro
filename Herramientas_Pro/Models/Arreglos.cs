using System.ComponentModel.DataAnnotations;

namespace Herramientas_Pro.Models
{
    public class Arreglos
    {
        [Key]
        public int Id { get; set; }  // Clave primaria recomendada
        public String Proyecto { get; set; }
        public String Cliente { get; set; }
        public String Diseño { get; set; }
        public String Vidrios { get; set; }
        public String Baranda { get; set; }
        public String Zancas { get; set; }
        public String Montajes { get; set; }
        public String Peldaños { get; set; }
        public String Guia { get; set; }
        public String Tornilleria { get; set; }
        public String Otros { get; set; }
        public String Estado { get; set; }
        public String Cita { get; set; }
        public DateTime Fecha { get; set; }
        public String Responsable { get; set; }
    }
}
