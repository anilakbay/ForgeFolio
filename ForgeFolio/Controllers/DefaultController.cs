using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
