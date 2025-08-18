using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductService.IRepository;
using ProductService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var products = await _repository.GetProducts();
            if (products == null)
                return NotFound();
            return Ok(products);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var product = await _repository.GetProductById(id);
            if(product == null)
                return NotFound();
            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Product product)
        {
            var productCount = await _repository.InsertProduct(product);
            if (productCount <= 0)
                return BadRequest();

            return Ok("Product Saved Successfully!");
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Product product)
        {
            if(id != product.Id )
                return NotFound();

            var productCount = await _repository.UpdateProduct(product);
            if (productCount <= 0)
                return BadRequest();

            return Ok("Product Updated Successfully!");
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteCount = await _repository.DeleteProduct(id);
            if (deleteCount <= 0)
                return NotFound();

            return Ok("Product Deleted Successfylly!");
        }
    }
}
