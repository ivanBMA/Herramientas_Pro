using System.ComponentModel.DataAnnotations;

namespace Herramientas_Pro.Models
{
    public class Productos
    {
        
        [Key]
        public int Id { get; set; }  // Clave primaria recomendada
        public string Producto { get; set; }
        public string Categoria { get; set; }
        public string Info { get; set; }
        public string Especificacion { get; set; }
        public string Codigo_Producto { get; set; }
        public decimal Cantidad_Minima { get; set; }
        public decimal Coste_Unidad { get; set; }
        public string Ubicacion { get; set; }
    }
}
