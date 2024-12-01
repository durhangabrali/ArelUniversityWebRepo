using Services.Contracts;

namespace Services
{
        public class ServiceManager : IServiceManager
    {
        private readonly IProductService _productServices;
        private readonly ICategoryService _categoryService;
        public ServiceManager(IProductService productService, ICategoryService categoryService)
        {
            _productServices = productService;
            _categoryService = categoryService;
        }

        public IProductService ProductService => _productServices;

        public ICategoryService CategoryService => _categoryService;
    }
}