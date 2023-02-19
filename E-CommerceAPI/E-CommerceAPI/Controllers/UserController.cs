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
        private readonly string DateFormat;

        public UserController(IConfiguration configuration)
        {
            _context = new EcommerceContext();
            DateFormat = configuration["Constants:DateFormat"];
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
                user.CreatedAt = DateTime.Now.ToString(DateFormat);
                user.ModifiedAt = DateTime.Now.ToString(DateFormat);
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }

            return Ok("test complete");       
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
