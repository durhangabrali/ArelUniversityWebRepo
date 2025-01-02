using System.ComponentModel.DataAnnotations;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly IServiceManager _manager;

        public CategoryController(IServiceManager manager)
        {
            _manager = manager;
        }


        public IActionResult Index()
        {
           var model = _manager.CategoryService.GetAllCategories(false);
           return View(model);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] CategoryDtoForInsertion categoryDto)
        {
            if(ModelState.IsValid)
            {  
                _manager.CategoryService.CreateCategory(categoryDto);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update([FromRoute(Name="id")] int id)
        {           
           var model = _manager.CategoryService.GetOneCategoryForUpdate(id,false);
           return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] CategoryDtoForUpdate categoryDto)
        {
            if(ModelState.IsValid)
            {
                _manager.CategoryService.UpdateOneCategory(categoryDto);
                return RedirectToAction("Index");
            }
            return View();
        }



    }
}