using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Herramientas_Pro.Models
{
    public class Productos
    {
        
        [Key]
        public int Id { get; set; }  // Clave primaria recomendada
        public string Producto { get; set; }
        public string Categoria { get; set; }
        public string Codigo_Producto { get; set; }
        public decimal Cantidad_Minima { get; set; }
        public string Unidad { get; set; }
        public decimal Coste_Unidad { get; set; }
        public string Ubicacion { get; set; }

        public override string ToString()
        {
            return $"Producto: {Producto}, Categoria: {Categoria}, Codigo_Producto: {Codigo_Producto}, " +
                   $"Cantidad_Minima: {Cantidad_Minima}, Unidad: {Unidad}, Coste_Unidad: {Coste_Unidad}, " +
                   $"Ubicacion: {Ubicacion}";
        }
    }


}
