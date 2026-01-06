using ForgeFolio.Core.DTOs.Message;
using ForgeFolio.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.Controllers;

/// <summary>
/// Contact form submission controller
/// </summary>
public class ContactController : Controller
{
    private readonly IMessageService _messageService;

    public ContactController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    // Index action for /Contact route
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SendMessage(CreateMessageDto dto)
    {
        if (!ModelState.IsValid)
        {
            TempData["ErrorMessage"] = "Please fill in all required fields correctly.";
            return RedirectToAction("Index", "Default");
        }

        try
        {
            await _messageService.CreateMessageAsync(dto);
            TempData["SuccessMessage"] = "Your message has been sent successfully! We'll get back to you soon.";
            return RedirectToAction("Index", "Default");
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"An error occurred while sending your message: {ex.Message}";
            return RedirectToAction("Index", "Default");
        }
    }
}
