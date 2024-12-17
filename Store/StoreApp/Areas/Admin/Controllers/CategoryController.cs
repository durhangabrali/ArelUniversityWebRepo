using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]  
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Product product)
        {
            return View();
        }
    }
}