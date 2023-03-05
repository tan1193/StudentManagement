using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
