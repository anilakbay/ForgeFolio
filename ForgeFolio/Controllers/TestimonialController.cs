using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.Controllers;

/// <summary>
/// Testimonial management controller
/// </summary>
// [Authorize(Roles = "Admin")] // Temporarily disabled
public class TestimonialController : Controller
{
    public IActionResult Index()
    {
        // TODO: Fetch real data
        return View();
    }

    [HttpGet]
    public IActionResult CreateTestimonial()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateTestimonial(string ClientName, string Company, string Comment, int Rating)
    {
        // TODO: Service integration
        TempData["SuccessMessage"] = "Testimonial başarıyla eklendi!";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult UpdateTestimonial(int id)
    {
        // TODO: Fetch by id
        return View();
    }

    [HttpPost]
    public IActionResult UpdateTestimonial(int id, string ClientName, string Company, string Comment, int Rating)
    {
        // TODO: Service integration
        TempData["SuccessMessage"] = "Testimonial başarıyla güncellendi!";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult DeleteTestimonial(int id)
    {
        // TODO: Service integration
        TempData["SuccessMessage"] = "Testimonial silindi!";
        return RedirectToAction(nameof(Index));
    }
}
