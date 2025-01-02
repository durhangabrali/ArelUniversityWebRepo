namespace Entities.Models
{
    public class CartLine
    {
        public int CartLineId { get; set; }        
        
        //Ürün tanımlanacak ve tanımlandığı yerde doğrudan referans alması sağlanacaktır.
        public Product Product { get; set; } = new();
        
        //Sepete atılan ürün adedi
        public int Quantity { get; set; }
        
    }
}