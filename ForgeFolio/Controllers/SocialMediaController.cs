<<<<<<< HEAD
using ForgeFolio.Core.DTOs.SocialMedia;
using ForgeFolio.Core.Interfaces.Services;
=======
>>>>>>> anildev
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.Controllers;

<<<<<<< HEAD
[Authorize(Roles = "Admin")]
public class SocialMediaController : Controller
{
    private readonly ISocialMediaService _socialMediaService;

    public SocialMediaController(ISocialMediaService socialMediaService)
    {
        _socialMediaService = socialMediaService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var values = await _socialMediaService.GetAllSocialMediasAsync();
        return View(values);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSocialMediaDto dto)
    {
        if (ModelState.IsValid)
        {
            await _socialMediaService.CreateSocialMediaAsync(dto);
            return RedirectToAction("Index");
        }
        return View(dto);
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var value = await _socialMediaService.GetSocialMediaByIdAsync(id);
        if (value == null)
        {
            return NotFound();
        }

        var updateDto = new UpdateSocialMediaDto
        {
            Id = value.Id,
            Title = value.Title,
            Url = value.Url,
            Icon = value.Icon
        };

        return View(updateDto);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateSocialMediaDto dto)
    {
        if (ModelState.IsValid)
        {
            await _socialMediaService.UpdateSocialMediaAsync(dto.Id, dto);
            return RedirectToAction("Index");
        }
        return View(dto);
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _socialMediaService.DeleteSocialMediaAsync(id);
        return RedirectToAction("Index");
    }
=======
/// <summary>
/// Social Media management controller
/// </summary>
// [Authorize(Roles = "Admin")] // Temporarily disabled
public class SocialMediaController : Controller
{
    // Simple Index action - no service needed yet
    public IActionResult Index()
    {
        return View();
    }
>>>>>>> anildev
}
