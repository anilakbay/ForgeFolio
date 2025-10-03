using ForgeFolio.DAL.Context;
using ForgeFolio.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.Controllers
{
    public class ContactController : Controller
    {
        private readonly MyPortfolioContext _context;

        public ContactController(MyPortfolioContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            if (ModelState.IsValid)
            {
                message.MessageDate = DateTime.Now;
                message.IsRead = false;
                
                _context.Messages.Add(message);
                _context.SaveChanges();
                
                TempData["SuccessMessage"] = "Your message has been sent successfully!";
                return RedirectToAction("Index", "Default");
            }
            
            TempData["ErrorMessage"] = "Please fill in all required fields.";
            return RedirectToAction("Index", "Default");
        }
    }
}
