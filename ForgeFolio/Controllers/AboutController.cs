using ForgeFolio.Core.DTOs.About;
using ForgeFolio.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.Controllers;

[Authorize(Roles = "Admin")]
public class AboutController : Controller
{
    private readonly IAboutService _aboutService;

    public AboutController(IAboutService aboutService)
    {
        _aboutService = aboutService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var value = await _aboutService.GetAboutAsync();
        return View(value);
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var value = await _aboutService.GetAboutAsync();
        if (value == null || value.Id != id) // Basic validation
        {
             // If no about exists, maybe redirect to Create? 
             // Start-up seeding should ensure one exists.
             return NotFound();
        }

        var updateDto = new UpdateAboutDto
        {
            Id = value.Id,
            Title = value.Title,
            SubDescription = value.SubDescription,
            Details = value.Details
        };

        return View(updateDto);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateAboutDto updateAboutDto)
    {
        if (ModelState.IsValid)
        {
            await _aboutService.UpdateAboutAsync(updateAboutDto);
            return RedirectToAction("Index");
        }
        return View(updateAboutDto);
    }
}
