using E_CommerceAPI.Common;
using E_CommerceAPI.DALRepository;
using E_CommerceAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Unicode;

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
        private readonly IConfiguration _configuration;
        public ShoppingController(IDataAccess dataAccess, IConfiguration configuration)
        {
            context = new EcommerceContext();
            this.dataAccess = dataAccess;
            _configuration = configuration;
            DateFormat = _configuration.GetValue<string>(Constants.DateFormat.DateFormatddd);
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

        [HttpPost("RegisterUser")]
        public IActionResult RegisterUser([FromBody] User user)
        {
            user.CreatedAt = DateTime.Now.ToString(DateFormat);
            user.ModifiedAt = DateTime.Now.ToString(DateFormat);

            context.Users.AddAsync(user);
            context.SaveChangesAsync();

            string? message;
            message = "inserted";

            return Ok(message);
        }

        [HttpPost]
        public IActionResult LoginUser([FromBody] User user)
        {
            try
            {
                if (user == null) return Ok("invalid");
                var query = context.Users.First(x => x.Email == user.Email && x.Password == user.Password);
                if (query == null)
                {
                    return Ok("invalid");
                }
                else
                {
                    string key = "rg0404p3k340kgafjk";
                    string expireTime = "1";
                    var symmetrickey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Issuer = "localhost",
                        Audience = "localhost",
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("id", user.UserId.ToString()),
                            new Claim("firstName", user.FirstName),
                            new Claim("lastName", user.LastName),
                            new Claim("address", user.Address),
                            new Claim("mobile", user.Mobile),
                            new Claim("email", user.Email),
                            new Claim("createdAt", user.CreatedAt),
                            new Claim("modifiedAt", user.ModifiedAt)
                        }),
                        Expires = DateTime.UtcNow.AddDays(Int16.Parse(expireTime)),
                        SigningCredentials = new SigningCredentials(symmetrickey, SecurityAlgorithms.HmacSha256Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                    var token = tokenHandler.WriteToken(securityToken);
                    return Ok(new { token });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
