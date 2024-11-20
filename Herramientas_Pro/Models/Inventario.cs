using System.Collections.Generic;
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
        public Double Comprar { get; set; }

        // Método para actualizar el campo Comprar basado en el stock y la cantidad mínima
        public Double ActualizarComprar(Inventario inventario,double cantidadSalida)
        {

            if (inventario.stock < inventario.Cantidad_Minima)
            {
                inventario.Comprar = inventario.Cantidad_Minima - inventario.stock;
            }
            else {
                inventario.Comprar = 0;
            }


            return inventario.Comprar;
        }

        public Double ActualizarStock(Inventario inventario, double cantidadSalida)
        {
            inventario.stock = inventario.stock + cantidadSalida;
            return inventario.stock;
        }
    }


}
