using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.IRepository;
using ProductService.Models;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendorRepository _repository;
        public VendorController(IVendorRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<VendorController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var vendors = await _repository.GetVendors();
            if (vendors == null)
                return NotFound();
            return Ok(vendors);
        }

        // GET api/<VendorController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var vendor = await _repository.GetVendorById(id);
            if (vendor == null)
                return NotFound();
            return Ok(vendor);
        }

        // POST api/<VendorController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Vendor vendor)
        {
            var vendorCount = await _repository.InsertVendor(vendor);
            if (vendorCount <= 0)
                return BadRequest();

            return Ok("Vendor Saved Successfully!");
        }

        // PUT api/<VendorController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Vendor vendor)
        {
            if (id != vendor.Id)
                return NotFound();

            var vendorCount = await _repository.UpdateVendor(vendor);
            if (vendorCount <= 0)
                return BadRequest();

            return Ok("Vendor Updated Successfully!");
        }

        // DELETE api/<VendorController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteCount = await _repository.DeleteVendor(id);
            if (deleteCount <= 0)
                return NotFound();

            return Ok("Vendor Deleted Successfylly!");
        }
    }
}
