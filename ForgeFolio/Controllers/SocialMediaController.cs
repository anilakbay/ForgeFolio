using ForgeFolio.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.Controllers;

/// <summary>
/// Social Media management controller
/// </summary>
// [Authorize(Roles = "Admin")] // Temporarily disabled
public class SocialMediaController : Controller
{
    private readonly ISocialMediaService _socialMediaService;

    public SocialMediaController(ISocialMediaService socialMediaService)
    {
        _socialMediaService = socialMediaService;
    }

    public async Task<IActionResult> Index()
    {
        var socialMedias = await _socialMediaService.GetAllSocialMediaAsync();
        return View(socialMedias);
    }

    [HttpGet]
    public IActionResult CreateSocialMedia()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateSocialMedia(ForgeFolio.Core.DTOs.SocialMedia.CreateSocialMediaDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        try
        {
            await _socialMediaService.CreateSocialMediaAsync(dto);
            TempData["SuccessMessage"] = "Sosyal medya hesabı başarıyla eklendi!";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Hata: {ex.Message}";
            return View(dto);
        }
    }

    [HttpGet]
    public async Task<IActionResult> UpdateSocialMedia(int id)
    {
        var socialMedia = await _socialMediaService.GetSocialMediaByIdAsync(id);
        if (socialMedia == null)
        {
            TempData["ErrorMessage"] = "Sosyal medya hesabı bulunamadı!";
            return RedirectToAction(nameof(Index));
        }

        var updateDto = new ForgeFolio.Core.DTOs.SocialMedia.UpdateSocialMediaDto
        {
            Title = socialMedia.Title,
            Url = socialMedia.Url,
            Icon = socialMedia.Icon
        };

        ViewBag.Id = id;
        return View(updateDto);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateSocialMedia(int id, ForgeFolio.Core.DTOs.SocialMedia.UpdateSocialMediaDto dto)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Id = id;
            return View(dto);
        }

        try
        {
            await _socialMediaService.UpdateSocialMediaAsync(id, dto);
            TempData["SuccessMessage"] = "Sosyal medya hesabı başarıyla güncellendi!";
            return RedirectToAction(nameof(Index));
        }
        catch (KeyNotFoundException)
        {
            TempData["ErrorMessage"] = "Sosyal medya hesabı bulunamadı!";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Hata: {ex.Message}";
            ViewBag.Id = id;
            return View(dto);
        }
    }

    [HttpGet]
    public async Task<IActionResult> DeleteSocialMedia(int id)
    {
        try
        {
            await _socialMediaService.DeleteSocialMediaAsync(id);
            TempData["SuccessMessage"] = "Sosyal medya hesabı silindi!";
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Hata: {ex.Message}";
        }
        return RedirectToAction(nameof(Index));
    }
}
