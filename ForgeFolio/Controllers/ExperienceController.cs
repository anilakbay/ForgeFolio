using ForgeFolio.Core.DTOs.Experience;
using ForgeFolio.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.Controllers;

/// <summary>
/// Experience management controller
/// </summary>
// [Authorize(Roles = "Admin")] // Temporarily disabled
public class ExperienceController : Controller
{
    private readonly IExperienceService _experienceService;

    public ExperienceController(IExperienceService experienceService)
    {
        _experienceService = experienceService;
    }

    // [Authorize(Roles = "Admin")] // Temporarily disabled for testing
    public IActionResult Index()
    {
        // TODO: Fetch real data - var experiences = await _experienceService.GetAllExperiencesAsync();
        return View();
    }

    [HttpGet]
    public IActionResult CreateExperience()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateExperience(CreateExperienceDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        try
        {
            await _experienceService.CreateExperienceAsync(dto);
            TempData["SuccessMessage"] = "Experience created successfully!";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Error creating experience: {ex.Message}";
            return View(dto);
        }
    }

    public async Task<IActionResult> DeleteExperience(int id)
    {
        try
        {
            await _experienceService.DeleteExperienceAsync(id);
            TempData["SuccessMessage"] = "Experience deleted successfully!";
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Error deleting experience: {ex.Message}";
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> UpdateExperience(int id)
    {
        try
        {
            var experience = await _experienceService.GetExperienceByIdAsync(id);
            if (experience == null)
            {
                TempData["ErrorMessage"] = "Experience not found!";
                return RedirectToAction(nameof(Index));
            }

            var dto = new UpdateExperienceDto
            {
                Head = experience.Head,
                Title = experience.Title,
                Date = experience.Date,
                Description = experience.Description
            };

            return View(dto);
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Error loading experience: {ex.Message}";
            return RedirectToAction(nameof(Index));
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateExperience(int id, UpdateExperienceDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        try
        {
            await _experienceService.UpdateExperienceAsync(id, dto);
            TempData["SuccessMessage"] = "Experience updated successfully!";
            return RedirectToAction(nameof(Index));
        }
        catch (KeyNotFoundException)
        {
            TempData["ErrorMessage"] = "Experience not found!";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Error updating experience: {ex.Message}";
            return View(dto);
        }
    }
}
