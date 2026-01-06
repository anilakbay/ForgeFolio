using ForgeFolio.Core.DTOs.Portfolio;
using ForgeFolio.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.Controllers
{
    // [Authorize(Roles = "Admin")] // TODO: Enable after testing
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public async Task<IActionResult> Index()
        {
            var portfolios = await _portfolioService.GetAllPortfoliosAsync();
            return View(portfolios);
        }

        [HttpGet]
        public IActionResult CreatePortfolio()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePortfolio(CreatePortfolioDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            try
            {
                await _portfolioService.CreatePortfolioAsync(dto);
                TempData["SuccessMessage"] = "Portfolio başarıyla eklendi!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
                return View(dto);
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePortfolio(int id)
        {
            var portfolio = await _portfolioService.GetPortfolioByIdAsync(id);
            if (portfolio == null)
            {
                TempData["ErrorMessage"] = "Portfolio bulunamadı!";
                return RedirectToAction(nameof(Index));
            }

            var updateDto = new UpdatePortfolioDto
            {
                Title = portfolio.Title,
                SubTitle = portfolio.SubTitle,
                ImageUrl = portfolio.ImageUrl,
                Url = portfolio.Url,
                Description = portfolio.Description
            };

            ViewBag.Id = id;
            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePortfolio(int id, UpdatePortfolioDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Id = id;
                return View(dto);
            }

            try
            {
                await _portfolioService.UpdatePortfolioAsync(id, dto);
                TempData["SuccessMessage"] = "Portfolio başarıyla güncellendi!";
                return RedirectToAction(nameof(Index));
            }
            catch (KeyNotFoundException)
            {
                TempData["ErrorMessage"] = "Portfolio bulunamadı!";
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
        public async Task<IActionResult> DeletePortfolio(int id)
        {
            try
            {
                await _portfolioService.DeletePortfolioAsync(id);
                TempData["SuccessMessage"] = "Portfolio başarıyla silindi!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
