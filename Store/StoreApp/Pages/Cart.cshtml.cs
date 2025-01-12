using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using StoreApp.Infrastructure.Extention;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager _manager;
        public Cart Cart { get; set; }

        //Cart sayfasına hangi Url'den gelindiğini tutmak için bir prop tanımlanır
        public string ReturnUrl { get; set; } = "/";

        public CartModel(IServiceManager manager, Cart cartService)
        {
            _manager = manager; 
            Cart = cartService;
        }       

        public void OnGet(string returnUrl)
        {
            //?? anlamı şudur : returnUrl eğer null ise "/" (kök klasör) değeri atanır.
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();     
        }

        public IActionResult OnPost(int productId, string returnUrl)
        {
            //Service katmanı üzerinden veritabanına gidilir. productId'ye sahip ürün var ise sepete eklenir.
            Product? product = _manager.ProductService.GetOneProduct(productId,false);

            if (product is not null)
            {
                //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();    
                Cart.AddItem(product,1);
                //HttpContext.Session.SetJson<Cart>("cart",Cart);
            }

            return RedirectToPage(new  { returnUrl = returnUrl});  //returnUrl
        } 

        public IActionResult OnPostRemove(int id, string returnUrl)
        {
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart(); 
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.ProductId == id).Product);
            //HttpContext.Session.SetJson<Cart>("cart",Cart);
            return Page();
        }       
    }    
}