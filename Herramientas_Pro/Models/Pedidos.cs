using System.ComponentModel.DataAnnotations;

namespace Herramientas_Pro.Models
{
    public class Pedidos
    {
        [Key]
        public int Id { get; set; }  // Clave primaria recomendada
        public String Presupuestos { get; set; }
        public String Cliente { get; set; }
        public String Tipo { get; set; }
        public String Medicion { get; set; }
        public Boolean Nube_Puntos { get; set; }
        public String Estado { get; set; }
        public DateTime Fecha { get; set; }
        public String Diseño_Inicial { get; set; }
        public String Fimra { get; set; }
        public String Otros { get; set; }
        public String Responsable { get; set; }

    }
}
