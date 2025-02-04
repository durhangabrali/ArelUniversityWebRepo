using System.ComponentModel.DataAnnotations;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model = _manager.ProductService.GellAllProduct(false);
            return View(model);
        }    

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = GetCategoriesSelectList();
            return View();
        }

        private SelectList GetCategoriesSelectList()
        {
            return new SelectList(_manager.CategoryService.GetAllCategories(false),"CategoryId","CategoryName","1");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion productDto, IFormFile? file)
        {
            if(ModelState.IsValid)
            {
                if(file is not null)
                {
                    var guid = Guid.NewGuid().ToString();  
                    string ext = Path.GetExtension(file.FileName);
                    // file copy operation -----------------------------------                    
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","images", String.Concat(guid,ext));
                    using(var stream = new FileStream(path,FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    //------------------------------------------------------
                                  
                    
                    productDto.ImageUrl = String.Concat("/images/", String.Concat(guid,ext));
                }
                else
                {
                    productDto.ImageUrl ="/images/default.jpg";
                }
                
                _manager.ProductService.CreateProduct(productDto);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update([FromRoute(Name="id")] int id)
        {
           ViewBag.Categories = GetCategoriesSelectList();
           var model = _manager.ProductService.GetOneProductForUpdate(id,false);
           return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] ProductDtoForUpdate productDto, IFormFile? file)
        {
            
            if(ModelState.IsValid)
            {
                if(file is not null)
                {
                    var guid = Guid.NewGuid().ToString(); 
                    string ext = Path.GetExtension(file.FileName);
                    // file operation -------------------------------------
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","images",String.Concat(guid,ext));
                    using(var stream = new FileStream(path,FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    productDto.ImageUrl = String.Concat("/images/",String.Concat(guid,ext));
                    // -----------------------------------------------------
                }
                else
                {
                    productDto.ImageUrl ="/images/default.jpg";
                }                
                
                _manager.ProductService.UpdateOneProduct(productDto);
                
                return RedirectToAction("Index");
             }
            return View(); 
        }

        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _manager.ProductService.DeleteOneProduct(id);
            return RedirectToAction("Index");
        }
    }
}