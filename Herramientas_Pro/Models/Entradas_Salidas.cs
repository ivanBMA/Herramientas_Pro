using System.ComponentModel.DataAnnotations;

namespace Herramientas_Pro.Models
{
    public class Entradas_Salidas
    {
        [Key]
        public int Id { get; set; }  // Clave primaria recomendada
        public String Codigo { get; set; }
        public String Producto { get; set; }
        public Double Cantidad { get; set; }
        public String Unidad { get; set; }
        public DateTime Fecha { get; set; }
        public String Firma { get; set; }


    }
}
