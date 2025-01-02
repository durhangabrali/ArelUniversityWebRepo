namespace Entities.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; }
        public Cart()
        {
            Lines = new List<CartLine>();
        }

        public void AddItem(Product product, int quantity)
        {
            // Eklenecek ürün sepette mevcut mu diye konmtrol edilir. 
            // Mevcut ise miktarı artırılacak, değilse eklenecektir.
            CartLine? line = Lines.Where(l => l.Product.ProductId == product.ProductId).FirstOrDefault();
            if(line == null)
            {
                Lines.Add(new CartLine(){
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product) =>
            Lines.RemoveAll(l => l.Product.ProductId == product.ProductId);

        public decimal ComputeTotalValue() => 
            Lines.Sum(e => e.Product.Price * e.Quantity);

        public void Clear() => Lines.Clear();
    }
}