using ForgeFolio.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult CreateSkill()
        {
            // TODO: Return create form view
            return View();
        }

        [HttpPost]
        public IActionResult CreateSkill(string Title, int Value)
        {
            // TODO: Service integration - await _skillService.CreateSkillAsync(dto);
            TempData["SuccessMessage"] = "Skill başarıyla eklendi!";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult UpdateSkill(int id)
        {
            // TODO: Fetch skill by id and return edit form
            return View();
        }

        [HttpPost]
        public IActionResult UpdateSkill(int id, string Title, int Value)
        {
            // TODO: Service integration - await _skillService.UpdateSkillAsync(id, dto);
            TempData["SuccessMessage"] = "Skill başarıyla güncellendi!";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult DeleteSkill(int id)
        {
            // TODO: Delete skill and redirect to Index
            TempData["SuccessMessage"] = "Skill deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}
