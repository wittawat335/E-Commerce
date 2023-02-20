using E_CommerceAPI.Common;
using E_CommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_CommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly EcommerceContext _context;
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _context = new EcommerceContext();
            _configuration = configuration;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        [Route("GetUser")]
        public IActionResult GetUser()
        {
            var model = _context.Users.ToList();
            return Ok(model);
        }

        // POST: api/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (user != null)
            {
                var _dateFormat = _configuration[Constants.DateFormat.DateFormatddd];
                user.CreatedAt = DateTime.Now.ToString(_dateFormat);
                user.ModifiedAt = DateTime.Now.ToString(_dateFormat);
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }

            return Ok("test complete");       
        }

        
    }
}
