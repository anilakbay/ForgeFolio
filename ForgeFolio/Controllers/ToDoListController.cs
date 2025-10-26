using ForgeFolio.DAL.Context;
using ForgeFolio.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ForgeFolio.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly MyPortfolioContext _context;

        public ToDoListController(MyPortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.ToDoLists.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateToDoList()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateToDoList(ToDoList toDoList)
        {
            _context.ToDoLists.Add(toDoList);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateToDoList(int id)
        {
            var value = _context.ToDoLists.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateToDoList(ToDoList toDoList)
        {
            _context.ToDoLists.Update(toDoList);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ChangeToDoListStatusToTrue(int id)
        {
            var value = _context.ToDoLists.Find(id);
            if (value != null)
            {
                value.Status = true;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult ChangeToDoListStatusToFalse(int id)
        {
            var value = _context.ToDoLists.Find(id);
            if (value != null)
            {
                value.Status = false;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
