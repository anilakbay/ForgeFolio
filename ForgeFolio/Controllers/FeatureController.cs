<<<<<<< HEAD
using ForgeFolio.Core.DTOs.Feature;
=======
>>>>>>> anildev
using ForgeFolio.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

<<<<<<< HEAD
namespace ForgeFolio.Controllers;

[Authorize(Roles = "Admin")]
public class FeatureController : Controller
{
    private readonly IFeatureService _featureService;

    public FeatureController(IFeatureService featureService)
    {
        _featureService = featureService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var values = await _featureService.GetAllFeaturesAsync();
        return View(values);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateFeatureDto createFeatureDto)
    {
        if (ModelState.IsValid)
        {
            await _featureService.CreateFeatureAsync(createFeatureDto);
            return RedirectToAction("Index");
        }
        return View(createFeatureDto);
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var value = await _featureService.GetFeatureByIdAsync(id);
        if (value == null)
        {
            return NotFound();
        }

        var updateDto = new UpdateFeatureDto
        {
            Id = value.Id,
            Title = value.Title,
            Header = value.Header,
            NameSurname = value.NameSurname,
            Description = value.Description,
            Icon = value.Icon
        };

        return View(updateDto);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateFeatureDto updateFeatureDto)
    {
        if (ModelState.IsValid)
        {
            await _featureService.UpdateFeatureAsync(updateFeatureDto.Id, updateFeatureDto);
            return RedirectToAction("Index");
        }
        return View(updateFeatureDto);
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _featureService.DeleteFeatureAsync(id);
        return RedirectToAction("Index");
=======
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
>>>>>>> anildev
    }
}
