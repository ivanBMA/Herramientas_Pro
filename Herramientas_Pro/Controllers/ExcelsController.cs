using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Herramientas_Pro.Controllers;
using Herramientas_Pro.Models;
using Herramientas_Pro.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data;

[Authorize]

public class ExcelsController : Controller
{
    private readonly ILogger<ExcelsController> _logger;
    private readonly ProductosService _productosService;
    private readonly FabricacionsService _fabricacionsService;

    // Constructor explícito
    public ExcelsController(ILogger<ExcelsController> logger, ProductosService productosService, FabricacionsService fabricacionsService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _productosService = productosService ?? throw new ArgumentNullException(nameof(productosService));
        _fabricacionsService = fabricacionsService ?? throw new ArgumentNullException(nameof(fabricacionsService));
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CargarExcel(IFormFile excelFile)
    {
        if (excelFile == null || excelFile.Length == 0)
        {
            ModelState.AddModelError("", "Por favor selecciona un archivo válido.");
            return View();
        }

        try
        {
            // Leer el archivo Excel
            DataTable dataTable = LeerExcel(excelFile);

            var propiedadesModeloProductos = typeof(Productos).GetProperties().Select(p => p.Name).ToHashSet();
            var propiedadesModeloFabricacion = typeof(Fabricacion).GetProperties().Select(p => p.Name).ToHashSet();

            var contador = 0;
            var contadorProductos = 0;
            var contadorFabricacion = 0;

            Console.WriteLine("Comprobando columnas:");

            foreach (DataColumn column in dataTable.Columns)
            {
                if (propiedadesModeloProductos.Contains(column.ColumnName))
                {
                    _logger.LogInformation($"✔️ La columna '{column.ColumnName}' coincide con el modelo Productos.");
                    contadorProductos++;
                }
                if (propiedadesModeloFabricacion.Contains(column.ColumnName))
                {
                    _logger.LogInformation($"✔️ La columna '{column.ColumnName}' coincide con el modelo Fabricacion.");
                    contadorFabricacion++;
                }
                else
                {
                    _logger.LogInformation($"❌ La columna '{column.ColumnName}' no coincide con el modelo.");
                }
                contador++;
            }
            _logger.LogInformation("contador " + contador + " Bien " + contadorProductos);


            if (contadorProductos == contador || contadorFabricacion == contador) {
                _logger.LogInformation("Existe la tabla a la que hace referencia el excel");
                

                foreach(DataRow row in dataTable.Rows){

                    if (contadorProductos == contador)
                    {
                        Productos producto = new Productos
                        {
                            Producto = row["Producto"]?.ToString() ?? string.Empty,
                            Categoria = row["Categoria"]?.ToString() ?? string.Empty,
                            Codigo_Producto = row["Codigo_Producto"]?.ToString() ?? string.Empty,
                            Cantidad_Minima = decimal.TryParse(row["Cantidad_Minima"]?.ToString(), out var cantidadMinima) ? cantidadMinima : 0,
                            Unidad = row["Unidad"]?.ToString() ?? string.Empty,
                            Coste_Unidad = decimal.TryParse(row["Coste_Unidad"]?.ToString(), out var costeUnidad) ? costeUnidad : 0,
                            Ubicacion = row["Ubicacion"]?.ToString() ?? string.Empty
                        };

                        _logger.LogInformation("------------------------- Producto " + producto.ToString());
                        _productosService.CrearProducto(producto);
                    }
                    else {
                        Fabricacion fabricacion = new Fabricacion
                        {
                            Proyecto = row["Proyecto"]?.ToString() ?? string.Empty,
                            Cliente = row["Cliente"]?.ToString() ?? string.Empty,
                            Diseño = row["Diseño"]?.ToString() ?? string.Empty,
                            Vidrio = row["Vidrio"]?.ToString() ?? string.Empty,
                            Baranda = row["Baranda"]?.ToString() ?? string.Empty,
                            Zancas = row["Zancas"]?.ToString() ?? string.Empty,
                            Montajes = row["Montajes"]?.ToString() ?? string.Empty,
                            Plotters = row["Plotters"]?.ToString() ?? string.Empty,
                            Peldaños = row["Peldaños"]?.ToString() ?? string.Empty,
                            Guia = row["Guia"]?.ToString() ?? string.Empty,
                            Tornilleria = row["Tornilleria"]?.ToString() ?? string.Empty,
                        };

                        _logger.LogInformation("------------------------- Fabricacion ");
                        _fabricacionsService.CrearFabricacion(fabricacion);
                    }
                }

            }

            

            return View("Resultados", dataTable); // Muestra los datos en una nueva vista
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Error al procesar el archivo: {ex.Message}");
            return View();
        }
    }

    private DataTable LeerExcel(IFormFile file)
    {
        DataTable dataTable = new DataTable();

        using (var stream = file.OpenReadStream())
        {
            using (var workbook = new XLWorkbook(stream))
            {
                var worksheet = workbook.Worksheet(1); // Leer la primera hoja
                bool firstRow = true;

                foreach (var row in worksheet.Rows())
                {
                    if (firstRow)
                    {
                        // Usar la primera fila como nombres de columna
                        foreach (var cell in row.Cells())
                        {
                            dataTable.Columns.Add(cell.Value.ToString());
                        }
                        firstRow = false;
                    }
                    else
                    {
                        // Verificar si la fila tiene al menos una celda con contenido
                        if (row.Cells().Any(c => !string.IsNullOrWhiteSpace(c.Value.ToString())))
                        {
                            dataTable.Rows.Add(row.Cells().Select(c => c.Value.ToString()).ToArray());
                        }
                    }
                }
            }
        }

        return dataTable;
    }

}
