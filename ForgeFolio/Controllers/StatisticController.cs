using ForgeFolio.DAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.Controllers
{
    public class StatisticController : Controller
    {
        private readonly MyPortfolioContext _context;

        public StatisticController(MyPortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalSkills = _context.Skills.Count();
            ViewBag.TotalMessages = _context.Messages.Count();
            ViewBag.UnreadMessages = _context.Messages.Where(x => x.IsRead == false).Count();
            ViewBag.ReadMessages = _context.Messages.Where(x => x.IsRead == true).Count();
            return View();
        }
    }
}
