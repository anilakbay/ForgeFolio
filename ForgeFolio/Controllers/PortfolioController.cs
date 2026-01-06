using ForgeFolio.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult CreatePortfolio()
        {
            // TODO: Return create form view
            return View();
        }

        [HttpGet]
        public IActionResult UpdatePortfolio(int id)
        {
            // TODO: Fetch portfolio by id and return edit form
            return View();
        }

        [HttpGet]
        public IActionResult DeletePortfolio(int id)
        {
            // TODO: Delete portfolio and redirect to Index
            TempData["SuccessMessage"] = "Portfolio deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}
