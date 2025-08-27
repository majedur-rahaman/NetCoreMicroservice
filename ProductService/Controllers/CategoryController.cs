using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.IRepository;
using ProductService.Models;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repository;
        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<VendorController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var categories = await _repository.GetCategories();
            if (categories == null)
                return NotFound();
            return Ok(categories);
        }

        // GET api/<VendorController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var category = await _repository.GetCategoryById(id);
            if (category == null)
                return NotFound();
            return Ok(category);
        }

        // POST api/<VendorController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Category category)
        {
            var categoryCount = await _repository.InsertCategory(category);
            if (categoryCount <= 0)
                return BadRequest();

            return Ok("Category Saved Successfully!");
        }

        // PUT api/<VendorController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Category category)
        {
            if (id != category.Id)
                return NotFound();

            var categoryCount = await _repository.UpdateCategory(category);
            if (categoryCount <= 0)
                return BadRequest();

            return Ok("Category Updated Successfully!");
        }

        // DELETE api/<VendorController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteCount = await _repository.DeleteCategory(id);
            if (deleteCount <= 0)
                return NotFound();

            return Ok("Category Deleted Successfylly!");
        }
    }
}
