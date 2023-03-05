using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using System.Diagnostics;

namespace StudentManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public StudentController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}