<<<<<<< HEAD
using ForgeFolio.Core.DTOs.Skill;
=======
>>>>>>> anildev
using ForgeFolio.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

<<<<<<< HEAD
namespace ForgeFolio.Controllers;

[Authorize(Roles = "Admin")]
public class SkillController : Controller
{
    private readonly ISkillService _skillService;

    public SkillController(ISkillService skillService)
    {
        _skillService = skillService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var values = await _skillService.GetAllSkillsAsync();
        return View(values);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSkillDto createSkillDto)
    {
        if (ModelState.IsValid)
        {
            await _skillService.CreateSkillAsync(createSkillDto);
            return RedirectToAction("Index");
        }
        return View(createSkillDto);
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var value = await _skillService.GetSkillByIdAsync(id);
        if (value == null)
        {
            return NotFound();
        }

        var updateDto = new UpdateSkillDto
        {
            Id = value.Id,
            Title = value.Title,
            Value = value.Value
        };

        return View(updateDto);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateSkillDto updateSkillDto)
    {
        if (ModelState.IsValid)
        {
            await _skillService.UpdateSkillAsync(updateSkillDto.Id, updateSkillDto);
            return RedirectToAction("Index");
        }
        return View(updateSkillDto);
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _skillService.DeleteSkillAsync(id);
        return RedirectToAction("Index");
=======
namespace ForgeFolio.Controllers
{
    // [Authorize(Roles = "Admin")] // Temporarily disabled
    public class SkillController : Controller
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        public IActionResult Index()
        {
            // TODO: Fetch real data - var skills = await _skillService.GetAllSkillsAsync();
            return View();
        }
<<<<<<< HEAD
>>>>>>> anildev
=======

        [HttpGet]
        public IActionResult CreateSkill()
        {
            // TODO: Return create form view
            return View();
        }

        [HttpGet]
        public IActionResult UpdateSkill(int id)
        {
            // TODO: Fetch skill by id and return edit form
            return View();
        }

        [HttpGet]
        public IActionResult DeleteSkill(int id)
        {
            // TODO: Delete skill and redirect to Index
            TempData["SuccessMessage"] = "Skill deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
>>>>>>> anildev
    }
}
