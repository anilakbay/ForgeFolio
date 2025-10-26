using ForgeFolio.DAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.Controllers
{
    public class MessageController : Controller
    {
        private readonly MyPortfolioContext _context;

        public MessageController(MyPortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Inbox()
        {
            var values = _context.Messages.ToList();
            return View(values);
        }

        public IActionResult MarkAsRead(int id)
        {
            var value = _context.Messages.Find(id);
            value.IsRead = true;
            _context.Messages.Update(value);
            _context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public IActionResult MarkAsUnread(int id)
        {
            var value = _context.Messages.Find(id);
            value.IsRead = false;
            _context.Messages.Update(value);
            _context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public IActionResult Details(int id)
        {
            var value = _context.Messages.Find(id);
            return View(value);
        }
    }
}
