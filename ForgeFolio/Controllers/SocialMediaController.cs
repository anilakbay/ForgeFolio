using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.Controllers;

/// <summary>
/// Social Media management controller
/// </summary>
// [Authorize(Roles = "Admin")] // Temporarily disabled
public class SocialMediaController : Controller
{
    public IActionResult Index()
    {
        // TODO: Fetch real data
        return View();
    }

    [HttpGet]
    public IActionResult CreateSocialMedia()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateSocialMedia(string Title, string Url, string Icon)
    {
        // TODO: Service integration
        TempData["SuccessMessage"] = "Sosyal medya hesabı başarıyla eklendi!";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult UpdateSocialMedia(int id)
    {
        // TODO: Fetch by id
        return View();
    }

    [HttpPost]
    public IActionResult UpdateSocialMedia(int id, string Title, string Url, string Icon)
    {
        // TODO: Service integration
        TempData["SuccessMessage"] = "Sosyal medya hesabı başarıyla güncellendi!";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult DeleteSocialMedia(int id)
    {
        // TODO: Service integration
        TempData["SuccessMessage"] = "Sosyal medya hesabı silindi!";
        return RedirectToAction(nameof(Index));
    }
}
