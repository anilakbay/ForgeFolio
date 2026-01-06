using ForgeFolio.Core.DTOs.Message;
using ForgeFolio.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.Controllers;

/// <summary>
/// Message management controller
/// </summary>
public class MessageController : Controller
{
    private readonly IMessageService _messageService;

    public MessageController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public async Task<IActionResult> Inbox()
    {
        var messages = await _messageService.GetAllMessagesAsync();
        ViewBag.UnreadCount = await _messageService.GetUnreadCountAsync();
        return View(messages);
    }

    public async Task<IActionResult> MarkAsRead(int id)
    {
        try
        {
            await _messageService.MarkAsReadAsync(id);
            TempData["SuccessMessage"] = "Message marked as read.";
        }
        catch (KeyNotFoundException)
        {
            TempData["ErrorMessage"] = "Message not found!";
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Error: {ex.Message}";
        }

        return RedirectToAction(nameof(Inbox));
    }

    public async Task<IActionResult> MarkAsUnread(int id)
    {
        try
        {
            await _messageService.MarkAsUnreadAsync(id);
            TempData["SuccessMessage"] = "Message marked as unread.";
        }
        catch (KeyNotFoundException)
        {
            TempData["ErrorMessage"] = "Message not found!";
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Error: {ex.Message}";
        }

        return RedirectToAction(nameof(Inbox));
    }

    public async Task<IActionResult> Details(int id)
    {
        try
        {
            var message = await _messageService.GetMessageByIdAsync(id);
            if (message == null)
            {
                TempData["ErrorMessage"] = "Message not found!";
                return RedirectToAction(nameof(Inbox));
            }

            // Auto mark as read when viewing details
            if (!message.IsRead)
            {
                await _messageService.MarkAsReadAsync(id);
            }

            return View(message);
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Error loading message: {ex.Message}";
            return RedirectToAction(nameof(Inbox));
        }
    }
}
