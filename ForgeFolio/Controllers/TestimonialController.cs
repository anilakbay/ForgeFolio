<<<<<<< HEAD
using ForgeFolio.Core.DTOs.Testimonial;
using ForgeFolio.Core.Interfaces.Services;
=======
>>>>>>> anildev
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.Controllers;

<<<<<<< HEAD
[Authorize(Roles = "Admin")]
public class TestimonialController : Controller
{
    private readonly ITestimonialService _testimonialService;

    public TestimonialController(ITestimonialService testimonialService)
    {
        _testimonialService = testimonialService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var values = await _testimonialService.GetAllTestimonialsAsync();
        return View(values);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTestimonialDto dto)
    {
        if (ModelState.IsValid)
        {
            await _testimonialService.CreateTestimonialAsync(dto);
            return RedirectToAction("Index");
        }
        return View(dto);
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var value = await _testimonialService.GetTestimonialByIdAsync(id);
        if (value == null)
        {
            return NotFound();
        }

        var updateDto = new UpdateTestimonialDto
        {
            Id = value.Id,
            ClientName = value.ClientName,
            Comment = value.Comment,
            CompanyName = value.CompanyName,
            ImageUrl = value.ImageUrl
        };

        return View(updateDto);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateTestimonialDto dto)
    {
        if (ModelState.IsValid)
        {
            await _testimonialService.UpdateTestimonialAsync(dto.Id, dto);
            return RedirectToAction("Index");
        }
        return View(dto);
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _testimonialService.DeleteTestimonialAsync(id);
        return RedirectToAction("Index");
    }
=======
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
>>>>>>> anildev
}
