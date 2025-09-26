using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
