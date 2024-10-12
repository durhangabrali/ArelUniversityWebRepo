using ArelAkademi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArelAkademi.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Apply(Candidate candidate)
        {
            return View();
        }
    }
}