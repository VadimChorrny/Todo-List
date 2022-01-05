using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class TaskController : Controller
    {
        TaskContext db;
        public TaskController(TaskContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Tasks.ToList());
        }
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Tasks tasks)
        {
            if (!ModelState.IsValid) return View();
            db.Tasks.Add(tasks);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Complete(int? id)
        {
            if (id == null) return NotFound();
            db.Tasks.First(e => e.Id == id).IsCompleted = true;
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var taskToRemove = db.Tasks.Find(id);
            if(taskToRemove == null) return NotFound();
            db.Tasks.Remove(taskToRemove);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id <= 0) return NotFound();

            var task = db.Tasks.Find(id);

            if (task == null) return NotFound();

            return View(task);
        }
        [HttpPost]
        public IActionResult Edit(Tasks obj)
        {
            if (!ModelState.IsValid) return View();
            db.Tasks.Update(obj);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Info()
        {
            return View();
        }
    }
}
