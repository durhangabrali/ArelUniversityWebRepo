using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using AutoMapper;
using Entities.Dtos;

namespace Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public CategoryManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public IEnumerable<Category> GetAllCategories(bool trackChanges)
        {
            //Burada Category içerisinde GetAllCategories diye bir metodumuz yok, çünkü tanımlamadık!
            //Bunun yerine Base Class'ta FindAll diye bir metot tanımlamıştık, onu kullanabiliriz.
           return _manager.CategoryRepository.GetAllCategories(trackChanges);
        }

        public Category? GetOneCategory(int id, bool trackChanges)
        {
            var category = _manager.CategoryRepository.GetOneCategory(id, trackChanges);
            if (category == null)
                throw new Exception("Category not found");
            return category;
        }

        public void CreateCategory(CategoryDtoForInsertion categoryDto)
        {
            Category category = _mapper.Map<Category>(categoryDto);            
            _manager.CategoryRepository.Create(category);
            _manager.Save();
        }

        public void DeleteOneCategory(int id)
        {
            Category category = GetOneCategory(id, false);
            if(category is not null)
            {
                _manager.CategoryRepository.DeleteOneCategory(category);
                _manager.Save();
            }
           
        }

        public CategoryDtoForUpdate GetOneCategoryForUpdate(int id, bool trackChanges)
        {
            var category = GetOneCategory(id, trackChanges);
            var categoryDto = _mapper.Map<CategoryDtoForUpdate>(category);
            return categoryDto;
        }

        public void UpdateOneCategory(CategoryDtoForUpdate categoryDto)
        {           
            if(categoryDto is not null)
            {
                Category category = _mapper.Map<Category>(categoryDto);    
                _manager.CategoryRepository.UpdateOneCategory(category);
                _manager.Save();
            }
        }
    }
}