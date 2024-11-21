using Herramientas_Pro.Models;

namespace Herramientas_Pro.Services
{
    public class ProductosService
    {
        private readonly ApplicationDbContext _context;
        private readonly InventarioService _inventarioService;

        public ProductosService(ApplicationDbContext context, InventarioService inventarioService)
        {
            _context = context;
            _inventarioService = inventarioService;
        }

        public bool CrearProducto(Productos producto)
        {
            try
            {
                var productoExiste = _context.Productos.FirstOrDefault(e => e.Producto == producto.Producto);
                //No existe el Producto lo creamos
                if (productoExiste == null)
                {
                    _context.Productos.Add(producto);
                    _context.SaveChanges();

                    Inventario inventario = new()
                    {
                        Producto = producto.Producto,
                        Codigo_Producto = producto.Codigo_Producto,
                        stock = 0,
                        Unidad = producto.Unidad,
                        Cantidad_Minima = (double)producto.Cantidad_Minima,
                        Unidad2 = producto.Unidad,
                        Comprar = (double)producto.Cantidad_Minima
                    };

                    _inventarioService.CrearInventario(inventario);
                    return true;
                }
                //Existe el producto lo Actualizamoss
                else {
                    

                    // Actualizar únicamente los valores que han cambiado
                    if (!string.IsNullOrEmpty(producto.Producto) && producto.Producto != productoExiste.Producto)
                        productoExiste.Producto = producto.Producto;

                    if (!string.IsNullOrEmpty(producto.Categoria) && producto.Categoria != productoExiste.Categoria)
                        productoExiste.Categoria = producto.Categoria;

                    if (!string.IsNullOrEmpty(producto.Codigo_Producto) && producto.Codigo_Producto != productoExiste.Codigo_Producto)
                        productoExiste.Codigo_Producto = producto.Codigo_Producto; 

                    if (producto.Cantidad_Minima >= 0 && producto.Cantidad_Minima != productoExiste.Cantidad_Minima)
                        productoExiste.Cantidad_Minima = producto.Cantidad_Minima; 

                    if (!string.IsNullOrEmpty(producto.Unidad) && producto.Unidad != productoExiste.Unidad)
                        productoExiste.Unidad = producto.Unidad;

                    if (producto.Coste_Unidad >= 0 && producto.Coste_Unidad != productoExiste.Coste_Unidad)
                        productoExiste.Coste_Unidad = producto.Coste_Unidad;

                    if (!string.IsNullOrEmpty(producto.Ubicacion) && producto.Ubicacion != productoExiste.Ubicacion)
                        productoExiste.Ubicacion = producto.Ubicacion;


                    _context.Productos.Update(productoExiste);
                    _context.SaveChanges();

                    Inventario inventario = new()
                    {
                        Producto = producto.Producto,
                        Codigo_Producto = producto.Codigo_Producto,
                        Unidad = producto.Unidad,
                        Cantidad_Minima = (double)producto.Cantidad_Minima,
                        Unidad2 = producto.Unidad,
                    };

                    _inventarioService.EditarInventario(inventario, producto.Codigo_Producto);

                    return true;
                }
            }
            catch (Exception ex)
            {
                // Opcional: Registrar errores o manejarlos de otra forma
                Console.WriteLine($"Error al crear el producto: {ex.Message}");
                return false;
            }
        }

        public IEnumerable<Productos> ObtenerProductos()
        {
            return _context.Productos.ToList();
        }
    }
}
