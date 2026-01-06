using ForgeFolio.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.Controllers;

/// <summary>
/// Testimonial management controller
/// </summary>
// [Authorize(Roles = "Admin")] // Temporarily disabled
public class TestimonialController : Controller
{
    private readonly ITestimonialService _testimonialService;

    public TestimonialController(ITestimonialService testimonialService)
    {
        _testimonialService = testimonialService;
    }

    public async Task<IActionResult> Index()
    {
        var testimonials = await _testimonialService.GetAllTestimonialsAsync();
        return View(testimonials);
    }

    [HttpGet]
    public IActionResult CreateTestimonial()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateTestimonial(ForgeFolio.Core.DTOs.Testimonial.CreateTestimonialDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        try
        {
            await _testimonialService.CreateTestimonialAsync(dto);
            TempData["SuccessMessage"] = "Testimonial başarıyla eklendi!";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Hata: {ex.Message}";
            return View(dto);
        }
    }

    [HttpGet]
    public async Task<IActionResult> UpdateTestimonial(int id)
    {
        var testimonial = await _testimonialService.GetTestimonialByIdAsync(id);
        if (testimonial == null)
        {
            TempData["ErrorMessage"] = "Testimonial bulunamadı!";
            return RedirectToAction(nameof(Index));
        }

        var updateDto = new ForgeFolio.Core.DTOs.Testimonial.UpdateTestimonialDto
        {
            ClientName = testimonial.ClientName,
            CompanyName = testimonial.CompanyName,
            Comment = testimonial.Comment,
            ImageUrl = testimonial.ImageUrl
        };

        ViewBag.Id = id;
        return View(updateDto);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateTestimonial(int id, ForgeFolio.Core.DTOs.Testimonial.UpdateTestimonialDto dto)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Id = id;
            return View(dto);
        }

        try
        {
            await _testimonialService.UpdateTestimonialAsync(id, dto);
            TempData["SuccessMessage"] = "Testimonial başarıyla güncellendi!";
            return RedirectToAction(nameof(Index));
        }
        catch (KeyNotFoundException)
        {
            TempData["ErrorMessage"] = "Testimonial bulunamadı!";
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
    public async Task<IActionResult> DeleteTestimonial(int id)
    {
        try
        {
            await _testimonialService.DeleteTestimonialAsync(id);
            TempData["SuccessMessage"] = "Testimonial silindi!";
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Hata: {ex.Message}";
        }
        return RedirectToAction(nameof(Index));
    }
}
