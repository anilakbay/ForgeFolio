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

        public async Task<IActionResult> Index()
        {
            var skills = await _skillService.GetAllSkillsAsync();
            return View(skills);
        }

        [HttpGet]
        public IActionResult CreateSkill()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSkill(ForgeFolio.Core.DTOs.Skill.CreateSkillDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            try
            {
                await _skillService.CreateSkillAsync(dto);
                TempData["SuccessMessage"] = "Skill başarıyla eklendi!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
                return View(dto);
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSkill(int id)
        {
            var skill = await _skillService.GetSkillByIdAsync(id);
            if (skill == null)
            {
                TempData["ErrorMessage"] = "Skill bulunamadı!";
                return RedirectToAction(nameof(Index));
            }

            var updateDto = new ForgeFolio.Core.DTOs.Skill.UpdateSkillDto
            {
                Title = skill.Title,
                Value = skill.Value
            };

            ViewBag.Id = id;
            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSkill(int id, ForgeFolio.Core.DTOs.Skill.UpdateSkillDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Id = id;
                return View(dto);
            }

            try
            {
                await _skillService.UpdateSkillAsync(id, dto);
                TempData["SuccessMessage"] = "Skill başarıyla güncellendi!";
                return RedirectToAction(nameof(Index));
            }
            catch (KeyNotFoundException)
            {
                TempData["ErrorMessage"] = "Skill bulunamadı!";
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
        public async Task<IActionResult> DeleteSkill(int id)
        {
            try
            {
                await _skillService.DeleteSkillAsync(id);
                TempData["SuccessMessage"] = "Skill başarıyla silindi!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Hata: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
