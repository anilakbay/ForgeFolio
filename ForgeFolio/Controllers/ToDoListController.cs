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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ToDoList toDoList)
        {
            toDoList.Status = false;
            _context.ToDoLists.Add(toDoList);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var value = _context.ToDoLists.Find(id);
            _context.ToDoLists.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value = _context.ToDoLists.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult Edit(ToDoList toDoList)
        {
            _context.ToDoLists.Update(toDoList);          
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult MarkAsCompleted(int id)
        {
            var value = _context.ToDoLists.Find(id);
            value.Status = true;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult MarkAsPending(int id)
        {
            var value = _context.ToDoLists.Find(id);
            value.Status = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
