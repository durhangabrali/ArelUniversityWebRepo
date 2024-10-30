using Microsoft.AspNetCore.Mvc;
using ProductsApp.Models;
using System.Diagnostics;

namespace ProductsApp.Controllers
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
            List<Product> products = new List<Product>()
            {
                new Product{ ProductId = 1,ProductName="Samsung S6", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco " +
                "laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu " +
                "fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum", Price = 1000, OnSale=true},
                new Product{ ProductId = 2,ProductName="Samsung S7", Description="Lorem ipsum dolor sid.", Price = 2000, OnSale=true},
                new Product{ ProductId = 3,ProductName="Samsung S8", Description="Lorem ipsum dolor sid amed.", Price = 3000, OnSale=true},
                new Product{ ProductId = 4,ProductName="IPhone 6", Description="Lorem ipsum dolor.", Price = 4000, OnSale=true},
                new Product{ ProductId = 5,ProductName="IPhone 7S", Description="Lorem ipsum dolor sid.", Price = 4500, OnSale=false},
                new Product{ ProductId = 6,ProductName="IPhone 8", Description="Lorem ipsum dolor sid amed.", Price = 5000, OnSale=true},
                new Product{ ProductId = 7,ProductName="IPhone 9", Description="Lorem ipsum dolor.", Price = 7000, OnSale=false},

            };

            List<Category> categories = new List<Category>() 
            { 
                  new Category(){ Id=1,CategoryName="Telefon"},
                  new Category(){ Id=2,CategoryName="Tablet"},
                  new Category(){ Id=3,CategoryName="Laptop"}
            };

            //ViewBag ile ürün sayısını View'a gönderme
            ViewBag.NumberOfProducts = products.Where(x=>x.OnSale==true).Count();

            //ViewBag ile Kategoriler listesini View'a gönderme
            ViewBag.Categories = categories;

            return View(products);
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