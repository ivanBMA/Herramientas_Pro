using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Herramientas_Pro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Este es un mensaje informativo en la acción Index.");
            _logger.LogDebug("Este es un mensaje de depuración.");

            return View();
        }
    }
}
