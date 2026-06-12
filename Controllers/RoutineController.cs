using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using samplecrud.Data;
using samplecrud.Models;

namespace samplecrud.Controllers
{
    public class RoutineController : Controller
    {
        private readonly AppDbContext _context;

        public RoutineController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchText, string filter, string sortOrder)
        {
            var tasks = _context.RoutineTasks.AsQueryable();

            if (!string.IsNullOrEmpty(searchText))
            {
                tasks = tasks.Where(t => t.TaskName.ToLower().Contains(searchText.ToLower()));
            }

            if (filter == "Pending")
            {
                tasks = tasks.Where(t => t.Status == "Pending");
            }
            else if (filter == "Completed")
            {
                tasks = tasks.Where(t => t.Status == "Completed");
            }
            else if (filter == "High")
            {
                tasks = tasks.Where(t => t.Priority == "High");
            }
            else if (filter == "Overdue")
            {
                var today = DateTime.Today;
                tasks = tasks.Where(t =>
                    t.Status == "Pending" &&
                    t.DueDateTime.Date < today);
            }
            if (sortOrder == "name")
            {
                tasks = tasks.OrderBy(t => t.TaskName);
            }
            else if (sortOrder == "priority")
            {
                tasks = tasks.OrderBy(t => t.Priority);
            }
            else if (sortOrder == "date")
            {
                tasks = tasks.OrderBy(t => t.DueDateTime);
            }

            return View(tasks.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RoutineTask task)
        {
            _context.RoutineTasks.Add(task);
            _context.SaveChanges();
            TempData["Message"] = "Task added successfully!";
            return RedirectToAction("Index");
        }

        public IActionResult Analytics()
        {
            var tasks = _context.RoutineTasks.ToList();
            return View(tasks);
        }

        public IActionResult Edit(int id)
        {
            var task = _context.RoutineTasks.FirstOrDefault(t => t.Id == id);
            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(RoutineTask updatedTask)
        {
            _context.RoutineTasks.Update(updatedTask);
            _context.SaveChanges();
            TempData["Message"] = "Task updated successfully!";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var task = _context.RoutineTasks.FirstOrDefault(t => t.Id == id);

            if (task != null)
            {
                _context.RoutineTasks.Remove(task);
                _context.SaveChanges();
            }
            TempData["Message"] = "Task deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}