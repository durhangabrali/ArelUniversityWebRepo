using DataTransport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace DataTransport.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //ViewData
            ViewData["text1"] = "Arel Universitesi";
            ViewData["check1"] = true;

            //ViewBag
            ViewBag.text2 = "Ahmet Keskin";
            ViewBag.check2 = true;

            //TempData
            TempData["text3"] = "Bilgisayar Programcýlýðý";
            TempData["check3"] = false;

            //ViewBag ile gönderilen verileri View’da  HTML Helper ile yakalayýp  HTML kontrolleri üzerinde gösterebiliriz.
            ViewBag.text4 = "Figen Aksu";
            ViewBag.check4 = true;
            ViewBag.list1 =
                new SelectListItem[]
                {
                    new SelectListItem() {Text = "Web Programlama"},
                    new SelectListItem() {Text = "Nesne Tabanlý Programlama"},
                    new SelectListItem() {Text = "Mobil Programlama"},

                };

            //TempData ile tutulan veriler iki adým öteye gidebilirler. Verilerin önce bir View’a
            //oradan da baþka bir View’a taþýnmasý þeklinde bunu anlayabiliriz.
            TempData["t1"] = ViewBag.text4;
            TempData["c1"] = ViewBag.check4;

            //String Dizisini Controller'dan View'a taþýmak
            string[] kurslar = { "ASP.NET MVC Kursu","Java Kursu","C# Kursu"};

            return View(kurslar);
        }

        public IActionResult Contact()
        {
            ViewBag.text4 = TempData["t1"];
            ViewBag.check4 = TempData["c1"];
            return View();
        }
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}