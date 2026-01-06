using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.Controllers;

/// <summary>
/// Testimonial management controller
/// </summary>
// [Authorize(Roles = "Admin")] // Temporarily disabled
public class TestimonialController : Controller
{
    // Simple Index action - no service needed yet
    public IActionResult Index()
    {
        return View();
    }
}
