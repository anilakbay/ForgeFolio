using ForgeFolio.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.Controllers;

[Authorize(Roles = "Admin")]
public class StatisticController : Controller
{
    private readonly IStatisticService _statisticService;

    public StatisticController(IStatisticService statisticService)
    {
        _statisticService = statisticService;
    }

    public async Task<IActionResult> Index()
    {
        var statistics = await _statisticService.GetStatisticsAsync();
        
        // Retaining ViewBag for backward compatibility with View implementation if preferred, 
        // but ideally View should use Model.
        ViewBag.TotalSkills = statistics.TotalSkills;
        ViewBag.TotalMessages = statistics.TotalMessages;
        ViewBag.UnreadMessages = statistics.UnreadMessages;
        ViewBag.ReadMessages = statistics.ReadMessages;

        return View(statistics);
    }
}
