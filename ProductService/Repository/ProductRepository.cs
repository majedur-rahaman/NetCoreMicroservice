using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.IRepository;
using ProductService.Models;

namespace ProductService.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDBContext _dbContext;
        public ProductRepository(ProductDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> DeleteProduct(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            _dbContext.Products.Remove(product);
                
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _dbContext.Products.FindAsync(id); ;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            ////Lazy Loading
            //var products = await _dbContext.Products.ToListAsync();
            //for (int i=0;i<products.Count;i++)
            //{
            //    products[i].Vendor = _dbContext.Vendors.Where(v => v.Id == products[i].VendorId).FirstOrDefault();
            //    products[i].Category = _dbContext.Categories.Where(v => v.Id == products[i].CategoryId).FirstOrDefault();
            //}
            //Eager Loading
            var products = await _dbContext.Products.Include(c=>c.Category).Include(v=>v.Vendor).ToListAsync();


            return products;
        }

        public async Task<int> InsertProduct(Product product)
        {
             _dbContext.Products.Add(product);
            return await _dbContext.SaveChangesAsync();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateProduct(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }
    }
}
