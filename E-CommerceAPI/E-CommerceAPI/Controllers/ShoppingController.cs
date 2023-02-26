using E_CommerceAPI.DALRepository;
using E_CommerceAPI.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_CommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        readonly IDataAccess dataAccess;
        private readonly string DateFormat;
        private readonly EcommerceContext context;
        public ShoppingController(IDataAccess dataAccess, IConfiguration configuration)
        {
            context = new EcommerceContext();
            this.dataAccess = dataAccess;
            DateFormat = configuration["Constants:DateFormat"];
        }
        // GET: api/<ShoppingController>
        [HttpGet("GetCategoryList")]
        public IActionResult GetCategoryList()
        {
            return Ok(dataAccess.GetProductCategories());
        }

        [HttpGet("GetProducts")]
        public IActionResult GetProducts(string category, string subcategory, int count)
        {
            return Ok(dataAccess.GetProducts(category, subcategory, count));
        }

        [HttpGet("GetProduct/{id}")]
        public IActionResult GetProduct(int id)
        {
            return Ok(dataAccess.GetProduct(id));
        }
    }
}
