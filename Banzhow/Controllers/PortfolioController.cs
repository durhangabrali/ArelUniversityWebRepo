using Microsoft.AspNetCore.Mvc;

namespace Banzhow.Controllers
{
     public class PortfolioController : Controller
     {
          public IActionResult Index()
          {
            return View();
          }

          public IActionResult Project()
          {
             return View();
          }
        
     }
}