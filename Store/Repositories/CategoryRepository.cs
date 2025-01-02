using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext context) : base(context)
        {            
        }

        public void CreateCategory(Category category) => Create(category);

        public void DeleteOneCategory(Category category) => Remove(category);
        
        public IQueryable<Category> GetAllCategories(bool trackChanges) => FindAll(trackChanges);        

        public Category? GetOneCategory(int id, bool trackChanges)
        {
           return FindByCondition(p=>p.CategoryId.Equals(id),trackChanges);
        }

        public void UpdateOneCategory(Category category) => Update(category);
    }
}