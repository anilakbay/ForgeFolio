using ForgeFolio.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.Controllers
{
    // [Authorize(Roles = "Admin")] // Temporarily disabled
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            // TODO: Fetch real data - var about = await _aboutService.GetAboutAsync();
            return View();
        }

        [HttpPost]
        public IActionResult UpdateAbout(string Title, string SubDescription, string Details)
        {
            // TODO: Service integration - await _aboutService.UpdateAboutAsync(dto);
            TempData["SuccessMessage"] = "About bilgileri başarıyla güncellendi!";
            return RedirectToAction(nameof(Index));
        }
    }
}
