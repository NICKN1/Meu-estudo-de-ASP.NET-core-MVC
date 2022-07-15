using Meus_testes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Meus_testes.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Cliente()
        {
            List<String> nomes = new List<String>();
            nomes.Add("Microsoft");
            nomes.Add("Adobe");
            nomes.Add("Apples");
            nomes.Add("IBM");
            nomes.Add("Facebook");
            nomes.Add("Twitter");
            ViewBag.Nome = nomes[1];
            ViewBag.TodosCli = nomes;
            return View();
        }

        public IActionResult Produto()
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