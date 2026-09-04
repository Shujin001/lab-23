using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApp2ByChirag.Models;

namespace WebApp2ByChirag.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult MyRazorPage()
        {
            ViewBag.CurrentDateTime = DateTime.Now;
            ViewBag.Name = "Chirag Sharma";
            ViewBag.RollNo = 6; // replace with your actual roll number
            return View();
        }

        [HttpGet]
        public IActionResult Create() => View(new Student());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                TempData["Student"] = JsonSerializer.Serialize(student);
                return RedirectToAction(nameof(Details));
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Details()
        {
            var studentJson = TempData["Student"] as string;
            if (string.IsNullOrEmpty(studentJson))
            {
                return RedirectToAction(nameof(Create));
            }
            var student = JsonSerializer.Deserialize<Student>(studentJson);
            return View(student);
        }
    }
}
