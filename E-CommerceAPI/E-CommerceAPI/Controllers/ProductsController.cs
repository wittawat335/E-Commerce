using E_CommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_CommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly EcommerceContext _context;
        private readonly IConfiguration _configuration;

        public ProductsController(IConfiguration configuration)
        {
            _context = new EcommerceContext();
            _configuration = configuration;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        [Route("GetCategoryList")]
        public IActionResult GetProductCategories()
        {
            var model = _context.ProductCategories.ToList();
            return Ok(model);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
