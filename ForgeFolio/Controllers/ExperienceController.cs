using ForgeFolio.DAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly MyPortfolioContext _context;

        public ExperienceController(MyPortfolioContext context)
        {
            _context = context;
        }

        public IActionResult ExperienceList()
        {
            var values = _context.Experiences.ToList();
            return View(values);
        }
    }
}
