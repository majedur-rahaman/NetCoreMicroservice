using Microsoft.AspNetCore.Components.Web;

namespace ProductService.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; } = string.Empty;
        public Boolean IsActive { get; set; }
        //public virtual ICollection<Product>? Products { get; set; }
    }
}
