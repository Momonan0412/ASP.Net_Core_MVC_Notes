using FirstWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirstWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() // if the URL is /home/index then this would be executed
        {
            return View();
        }

        public IActionResult Privacy() // if the URL is /home/privacy then this would be executed
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
