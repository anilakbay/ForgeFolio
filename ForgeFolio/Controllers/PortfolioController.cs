<<<<<<< HEAD
using ForgeFolio.Core.DTOs.Portfolio;
=======
>>>>>>> anildev
using ForgeFolio.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

<<<<<<< HEAD
namespace ForgeFolio.Controllers;

[Authorize(Roles = "Admin")]
public class PortfolioController : Controller
{
    private readonly IPortfolioService _portfolioService;

    public PortfolioController(IPortfolioService portfolioService)
    {
        _portfolioService = portfolioService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(int page = 1)
    {
        int pageSize = 5;
        var values = await _portfolioService.GetAllPortfoliosPaginatedAsync(page, pageSize);
        return View(values);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePortfolioDto createPortfolioDto)
    {
        if (ModelState.IsValid)
        {
            await _portfolioService.CreatePortfolioAsync(createPortfolioDto);
            return RedirectToAction("Index");
        }
        return View(createPortfolioDto);
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var value = await _portfolioService.GetPortfolioByIdAsync(id);
        if (value == null)
        {
            return NotFound();
        }

        var updateDto = new UpdatePortfolioDto
        {
            Id = value.Id,
            Title = value.Title,
            SubTitle = value.SubTitle,
            ImageUrl = value.ImageUrl,
            Url = value.Url,
            Description = value.Description
        };

        return View(updateDto);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdatePortfolioDto updatePortfolioDto)
    {
        if (ModelState.IsValid)
        {
            await _portfolioService.UpdatePortfolioAsync(updatePortfolioDto.Id, updatePortfolioDto);
            return RedirectToAction("Index");
        }
        return View(updatePortfolioDto);
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _portfolioService.DeletePortfolioAsync(id);
        return RedirectToAction("Index");
=======
namespace ForgeFolio.Controllers
{
    // [Authorize(Roles = "Admin")] // Temporarily disabled for testing
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public IActionResult Index()
        {
            // TODO: Fetch real data - var portfolios = await _portfolioService.GetAllPortfoliosAsync();
            return View();
        }
>>>>>>> anildev
    }
}
