using Services.Contracts;

namespace Services
{
        public class ServiceManager : IServiceManager
    {
        private readonly IProductService _productServices;
        private readonly ICategoryService _categoryService;
        private readonly IOrderService _orderService;

        public ServiceManager(IProductService productService, ICategoryService categoryService, IOrderService orderService)
        {
            _productServices = productService;
            _categoryService = categoryService;
            _orderService = orderService;
        }

        public IProductService ProductService => _productServices;

        public ICategoryService CategoryService => _categoryService;

        public IOrderService OrderService => _orderService;
    }
}