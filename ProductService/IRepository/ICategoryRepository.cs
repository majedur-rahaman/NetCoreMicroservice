using Microsoft.AspNetCore.Mvc;
using ProductService.Models;

namespace ProductService.IRepository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategoryById(int id);
        Task<int> InsertCategory(Category category);
        Task<int> UpdateCategory(Category category);
        Task<int> DeleteCategory(int id);
    }
}
