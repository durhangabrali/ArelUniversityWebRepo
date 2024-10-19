using ArelAkademi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArelAkademi.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            var model = Repository.GetAllApplications;
            return View(model);
        }

        
        public IActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Apply([FromForm] Candidate candidate)
        {
            //Form verilerle birlikte sunucuya geldi.
            if(Repository.GetAllApplications.Any(x=>x.Email.Equals(candidate.Email)))
            {
                ModelState.AddModelError("", "Bu e-posta ile daha önceden başvuru yapılmış!");
            }


            if(ModelState.IsValid)
            {
               //Form'dan veriler geldi.
               Repository.Add(candidate);
               return View("Feedback",candidate);
            }
                     
            return View();
                   
        }
    }
}