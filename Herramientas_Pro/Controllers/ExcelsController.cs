using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Herramientas_Pro.Controllers;
using Herramientas_Pro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data;

public class ExcelsController : Controller
{
    private readonly ILogger<ExcelsController> _logger;

    public ExcelsController(ILogger<ExcelsController> logger)
    {
        _logger = logger;
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

            // Aquí puedes procesar o guardar los datos del DataTable
            // Por ejemplo: pasar los datos a la vista o guardarlos en la base de datos.
            // Obtener las propiedades del modelo
            /*
            var propiedadesModelo = typeof(Productos).GetProperties().Select(p => p.Name).ToHashSet();
            var contador = 0;
            var contadorB = 0;
            Console.WriteLine("Comprobando columnas:");

            foreach (DataColumn column in dataTable.Columns)
            {
                if (propiedadesModelo.Contains(column.ColumnName))
                {
                    _logger.LogInformation($"✔️ La columna '{column.ColumnName}' coincide con el modelo.");
                    contadorB++;
                }
                else
                {
                    _logger.LogInformation($"❌ La columna '{column.ColumnName}' no coincide con el modelo.");
                }
                contador++;
            }
            _logger.LogInformation("contador " + contador + " Bien " + contadorB);

            if (contadorB == contador) {
                _logger.LogInformation("Existe la tabla a la que hace referencia el excel");
                

                foreach(DataRow row in dataTable.Rows){
                    Productos producto = new Productos
                    {
                        Producto = row["Producto"].ToString(),
                        Categoria = row["Categoria"].ToString(),
                        Codigo_Producto = row["Codigo_Producto"].ToString(),
                        Cantidad_Minima = Convert.ToDecimal(row["Cantidad_Minima"]),
                        Unidad = row["Unidad"].ToString(),
                        Coste_Unidad = Convert.ToDecimal(row["Coste_Unidad"]),
                        Ubicacion = row["Ubicacion"].ToString()
                    };

                    //_context.Add(producto);
                    //_context.SaveChangesAsync();
                }

            }
            */

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
                        // Agregar las filas a la tabla
                        dataTable.Rows.Add(row.Cells().Select(c => c.Value.ToString()).ToArray());
                    }
                }
            }
        }

        return dataTable;
    }
}
