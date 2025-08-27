using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.IRepository;
using ProductService.Models;

namespace ProductService.Repository
{
    public class VendorRepository : IVendorRepository
    {
        private readonly ProductDBContext _dbContext;
        public VendorRepository(ProductDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> DeleteVendor(int id)
        {
            try
            {
                var vendor = await _dbContext.Vendors.FindAsync(id);
                if (vendor != null)
                {
                    _dbContext.Vendors.Remove(vendor);
                }
                else
                {
                    return 0;
                }

                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Vendor?> GetVendorById(int id)
        {
            return await _dbContext.Vendors.FindAsync(id);
        }

        public async Task<IEnumerable<Vendor>> GetVendors()
        {
            return await _dbContext.Vendors.ToListAsync();
        }

        public async Task<int> InsertVendor(Vendor vendor)
        {
             _dbContext.Vendors.Add(vendor);
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<int> UpdateVendor(Vendor vendor)
        {
            _dbContext.Entry(vendor).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }
    }
}
