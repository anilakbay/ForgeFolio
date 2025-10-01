using ForgeFolio.DAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.Controllers
{
    public class MessageController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IActionResult Inbox()
        {
            var values = context.Messages.ToList();
            return View(values);
        }
    }
}
