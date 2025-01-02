using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        
        public ProductManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateProduct(ProductDtoForInsertion productDto)
        {
            /// 1.yöntem : 
            /// ProductDto nesnesinden ilgili alanları tek-tek alarak Product nesnesine atayabiliriz.
            /// İlgili nesnenin çok sayıda property'si olduğunda bu yöntem biraz zaman alıcı olacaktır.
            /// Bunun yerine AutoMapper kullanılabilir.
            
            // Product product = new Product()
            // {
            //    ProductName = productDto.ProductName,
            //    Price = productDto.Price,
            //    CategoryId = productDto.CategoryId
            // };

            Product product = _mapper.Map<Product>(productDto);            
            _manager.ProductRepository.Create(product);
            _manager.Save();

        }

        public void DeleteOneProduct(int id)
        {
            Product product = GetOneProduct(id, false);
            if(product is not null)
            {
                _manager.ProductRepository.DeleteOneProduct(product);
                _manager.Save();
            }
           
        }

        public IEnumerable<Product> GellAllProduct(bool trackChanges)
        {
           return _manager.ProductRepository.GetAllProducts(trackChanges);
        }

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            var product = _manager.ProductRepository.GetOneProduct(id, trackChanges);
            if (product == null)
                throw new Exception("Product not found");
            return product;
        }

        public ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges)
        {
            var product = GetOneProduct(id, trackChanges);
            var productDto = _mapper.Map<ProductDtoForUpdate>(product);
            return productDto;
        }

        public void UpdateOneProduct(ProductDtoForUpdate productDto)
        {           
            if(productDto is not null)
            {
                Product product = _mapper.Map<Product>(productDto);    
                _manager.ProductRepository.UpdateOneProduct(product);
                _manager.Save();
            }
        }
    }
}