using ForgeFolio.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.Controllers
{
    // [Authorize(Roles = "Admin")] // Temporarily disabled
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public IActionResult Index()
        {
            // TODO: Fetch real data - var features = await _featureService.GetAllFeaturesAsync();
            return View();
        }

        [HttpGet]
        public IActionResult CreateFeature()
        {
            // TODO: Return create form view
            return View();
        }

        [HttpGet]
        public IActionResult UpdateFeature(int id)
        {
            // TODO: Fetch feature by id and return edit form
            return View();
        }

        [HttpGet]
        public IActionResult DeleteFeature(int id)
        {
            // TODO: Delete feature and redirect to Index
            TempData["SuccessMessage"] = "Feature deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}
