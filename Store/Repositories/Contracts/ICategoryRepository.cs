using Entities.Models;

namespace Repositories.Contracts
{
    public interface ICategoryRepository :  IRepositoryBase<Category>
     {
        IQueryable<Category> GetAllCategories(bool trackChanges);
        Category? GetOneCategory(int id, bool trackChanges);
        void CreateCategory(Category category);
        void UpdateOneCategory(Category category);
        void DeleteOneCategory(Category category);
     }
}