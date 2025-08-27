using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.IRepository;
using ProductService.Models;

namespace ProductService.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductDBContext _dbContext;
        public CategoryRepository(ProductDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> DeleteCategory(int id)
        {
            var category = await _dbContext.Categories.FindAsync(id);
            _dbContext.Categories.Remove(category);
                
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Category?> GetCategoryById(int id)
        {
            return await _dbContext.Categories.FindAsync(id); ;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<int> InsertCategory(Category category)
        {
             _dbContext.Categories.Add(category);
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<int> UpdateCategory(Category category)
        {
            _dbContext.Entry(category).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }
    }
}
