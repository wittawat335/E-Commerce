using E_CommerceAPI.Common;
using E_CommerceAPI.DALRepository;
using E_CommerceAPI.Entities;
using E_CommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using NuGet.Configuration;
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
            DateFormat = _configuration.GetValue<string>(Constants.AppSettings.DateFormat);
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
        [HttpGet("GetProductReviews/{productId}")]
        public IActionResult GetProductReviews(int productId)
        {
            try
            {
                var resultList = new List<ReviewModel>();
                var result = new ReviewModel();
                var review = context.Reviews.FirstOrDefault(x => x.ProductId == productId);
                var user = context.Users.FirstOrDefault(x => x.UserId == review.UserId);
                var product = context.Products.FirstOrDefault(x => x.ProductId == productId);
                //--------------Review----------------------/
                result.Value = review.Description;
                result.Id = review.ReviewId;
                result.CreatedAt = review.CreatedAt;
                //---------User-------------------///
                result.User.Id = user.UserId;
                result.User.FirstName = user.FirstName;
                result.User.LastName = user.LastName;
                result.User.Email = user.Email;
                result.User.Address = user.Address;
                result.User.Mobile = user.Mobile;
                result.User.Password = user.Password;
                result.User.CreatedAt = user.CreatedAt;
                result.User.ModifiedAt = user.ModifiedAt;
                //------------------------------------///
                result.Product.Id = product.ProductId;
                result.Product.Title = product.Title;
                result.Product.Description = product.Description;
                result.Product.Price = product.Price;
                result.Product.Quantity = product.Quantity;
                result.Product.ImageName = product.ImageName;
                resultList.Add(result);

                return Ok(resultList);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
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

        [HttpPost("LoginUser")]
        public IActionResult LoginUser([FromBody] UserModel user)
        {
            try
            {
                if (user == null) return Ok("invalid");
                var query = context.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
                //var query = context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
                if (query == null)
                {
                    return Ok("invalid");
                }
                else
                {
                    string key = _configuration.GetValue<string>(Constants.AppSettings.JWT_Secret);
                    string expireTime = _configuration.GetValue<string>(Constants.AppSettings.JWT_ExpireTime);
                    var symmetrickey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Issuer = _configuration.GetValue<string>(Constants.AppSettings.JWT_TokenDescriptor_Issuer),
                        Audience = _configuration.GetValue<string>(Constants.AppSettings.JWT_TokenDescriptor_Audience),
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("id", query.UserId.ToString()),
                            new Claim("firstName", query.FirstName),
                            new Claim("lastName", query.LastName),
                            new Claim("address", query.Address),
                            new Claim("mobile", query.Mobile),
                            new Claim("email", query.Email),
                            new Claim("createdAt", query.CreatedAt),
                            new Claim("modifiedAt", query.ModifiedAt)
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

        [HttpPost("InsertReview")]
        public IActionResult InsertReview([FromBody] ReviewModel review)
        {
            try
            {
                if (review == null) return Ok("Data from Client is NUll");

                var model = new Review();
                model.UserId = review.User.Id;
                model.ProductId = review.Product.Id;
                model.Description = review.Value;
                model.CreatedAt = DateTime.Now.ToString(DateFormat);

                context.Reviews.AddAsync(model);
                context.SaveChangesAsync();

                string? message;
                message = "inserted";

                return Ok(message);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
