namespace ProductService.Models
{
    public class Product
    {
        public Product()
        {
            this.Categories = new HashSet<Category>();
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Boolean IsActive { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
