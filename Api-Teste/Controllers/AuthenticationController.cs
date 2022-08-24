using Microsoft.AspNetCore.Mvc;

namespace Api_Teste.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
