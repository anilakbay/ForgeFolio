using ForgeFolio.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.ViewComponents.LayoutViewComponents
{
    public class _LayoutNavbarComponentPartial: ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public _LayoutNavbarComponentPartial(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.UnreadMessageCount = _context.Messages.Where(x => x.IsRead == false).Count();
            var values = _context.Messages.Where(x => x.IsRead == false).ToList();
            return View(values);
        }
    }
}
