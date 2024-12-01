using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;

        public CategoryManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IEnumerable<Category> GetAllCategories(bool trackChanges)
        {
            //Burada Category içerisinde GetAllCategories diye bir metodumuz tok, çünkü tanımlamadık!
            //Bunun yerine Base Class'ta FindAll diye bir metot tanımlamıştık, onu kullanabiliriz.
           return _manager.Category.FindAll(trackChanges);
        }
    }
}