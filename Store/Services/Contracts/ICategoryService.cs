using Entities.Models;
using Entities.Dtos;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories(bool trackChanges);
        Category? GetOneCategory(int id, bool trackChanges);   
        void CreateCategory(CategoryDtoForInsertion categoryDto);   
        void UpdateOneCategory(CategoryDtoForUpdate categoryDto);
        void DeleteOneCategory(int id);
        CategoryDtoForUpdate GetOneCategoryForUpdate(int id, bool trackChanges);
    }
}
