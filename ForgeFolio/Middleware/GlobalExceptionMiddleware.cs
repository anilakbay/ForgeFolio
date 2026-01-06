using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.Middleware;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred: {Message}", ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        // If it's an AJAX request or API call, return JSON
        if (IsAjaxRequest(context))
        {
            var response = new
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error. Please try again later.",
                Detailed = exception.Message // In production, hide this
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        // For normal MVC requests, redirect to Error page
        context.Response.Redirect("/Home/Error");
        return Task.CompletedTask;
    }

    private static bool IsAjaxRequest(HttpContext context)
    {
        return context.Request.Headers["X-Requested-With"] == "XMLHttpRequest" || 
               context.Request.Headers["Accept"].ToString().Contains("application/json");
    }
}
