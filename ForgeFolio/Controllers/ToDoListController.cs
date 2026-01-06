using ForgeFolio.Core.DTOs.ToDoList;
using ForgeFolio.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ToDoListController : Controller
    {
        private readonly IToDoListService _toDoListService;

        public ToDoListController(IToDoListService toDoListService)
        {
            _toDoListService = toDoListService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _toDoListService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateToDoListDto createDto)
        {
            if (ModelState.IsValid)
            {
                await _toDoListService.CreateAsync(createDto);
                return RedirectToAction("Index");
            }
            return View(createDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _toDoListService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var value = await _toDoListService.GetByIdAsync(id);
            if (value == null)
            {
                return NotFound();
            }

            var updateDto = new UpdateToDoListDto
            {
                Id = value.Id,
                Title = value.Title,
                Description = value.Description,
                ImageUrl = value.ImageUrl,
                Date = value.Date,
                Status = value.Status
            };

            return View(updateDto); // View expects UpdateToDoListDto? Need to check View.
            // In Step 623 (UpdateToDoList.cshtml), we set @model ForgeFolio.Core.Entities.ToDoList.
            // Wait! The View expects Entity!
            // But I should refactor View to expect DTO (UpdateToDoListDto).
            // I will refactor the View as well in next step or now?
            // Sending Dto to Entity-view might break if property names differ.
            // Dto has same properties (Title, Date, ImageUrl, Id).
            // View uses asp-for="Id", Title, Date, ImageUrl.
            // So it matches.
            // BUT, View has @model ForgeFolio.Core.Entities.ToDoList.
            // I MUST change View Model to UpdateToDoListDto.
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateToDoListDto updateDto)
        {
             if (ModelState.IsValid)
            {
                await _toDoListService.UpdateAsync(updateDto);
                return RedirectToAction("Index");
            }
            return View(updateDto);
        }

        [HttpGet]
        public async Task<IActionResult> MarkAsCompleted(int id)
        {
            await _toDoListService.ChangeStatusAsync(id, true);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> MarkAsPending(int id)
        {
            await _toDoListService.ChangeStatusAsync(id, false);
            return RedirectToAction("Index");
        }
    }
}
