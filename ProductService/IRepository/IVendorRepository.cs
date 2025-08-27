using ProductService.Models;

namespace ProductService.IRepository
{
    public interface IVendorRepository
    {
        Task<IEnumerable<Vendor>> GetVendors();
        Task<Vendor> GetVendorById(int id);
        Task<int> InsertVendor(Vendor vendor);
        Task<int> UpdateVendor(Vendor vendor);
        Task<int> DeleteVendor(int id);
    }
}
