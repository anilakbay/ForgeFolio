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

        public async Task<IActionResult> Index()
        {
            var about = await _aboutService.GetAboutAsync();
            return View(about);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(ForgeFolio.Core.DTOs.About.UpdateAboutDto dto)
        {
            if (!ModelState.IsValid)
            {
               return View("Index", await _aboutService.GetAboutAsync());
            }

            try
            {
                 await _aboutService.UpdateAboutAsync(dto);
                 TempData["SuccessMessage"] = "Hakkımda bilgileri başarıyla güncellendi!";
            }
            catch (Exception ex)
            {
                 TempData["ErrorMessage"] = $"Hata: {ex.Message}";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
