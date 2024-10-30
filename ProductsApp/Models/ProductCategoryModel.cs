namespace ProductsApp.Models
{
    public class ProductCategoryModel
    {
        public int NumberOfProducts { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
    }
}
