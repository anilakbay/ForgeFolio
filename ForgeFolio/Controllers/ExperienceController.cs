using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.Controllers
{
    public class ExperienceController : Controller
    {
        public IActionResult ExperienceList()
        {
            return View();
        }
    }
}
