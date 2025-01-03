using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager _manager;

        public CartModel(IServiceManager manager, Cart cart)
        {
            _manager = manager;
            Cart = cart;
        }

        public Cart Cart { get; set; }

        //Cart sayfasına hangi Url'den gelindiğini tutmak için bir prop tanımlanır
        public string ReturnUrl { get; set; } = "/";

        public void OnGet(string returnUrl)
        {
            //?? anlamı şudur : returnUrl eğer null ise "/" (kök klasör) değeri atanır.
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int productId, string returnUrl)
        {
            //Service katmanı üzerinden veritabanına gidilir. productId'ye sahip ürün var ise sepete eklenir.
            Product? product = _manager.ProductService.GetOneProduct(productId,false);

            if (product is not null)
            {
                Cart.AddItem(product,1);
            }

            return Page();
        } 

        public IActionResult OnPostRemove(int id, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl=>cl.Product.ProductId == id).Product);
            return Page();
        }       
    }    
}