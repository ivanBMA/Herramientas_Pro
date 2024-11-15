using System.ComponentModel.DataAnnotations;

namespace Herramientas_Pro.Models
{
    public class Inventario
    {
        [Key]
        public int Id { get; set; }  // Clave primaria recomendada
        public String Producto { get; set; }
        public String Codigo_Producto { get; set; }
        public double stock { get; set; }
        public String Unidad { get; set; }
        public double Cantidad_Minima { get; set; }
        public String Unidad2 { get; set; }
        public String Comprar { get; set; }


    }
}
