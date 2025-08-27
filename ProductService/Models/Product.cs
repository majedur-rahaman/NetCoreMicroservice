namespace ProductService.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Boolean IsActive { get; set; }
        public int VendorId { get; set; }
        public virtual Vendor? Vendor { get; set; }
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }
}
