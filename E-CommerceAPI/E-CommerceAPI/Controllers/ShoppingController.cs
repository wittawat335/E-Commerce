using E_CommerceAPI.Common;
using E_CommerceAPI.DALRepository;
using E_CommerceAPI.Entities;
using E_CommerceAPI.Models;
using E_CommerceAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                var resultList = new List<ReviewViewModel>();
                var review = context.Reviews.Where(x => x.ProductId == productId).ToList();
                foreach (var item in review)
                {
                    var result = new ReviewViewModel();
                    //--------------Review----------------------/
                    result.Value = item.Description;
                    result.Id = item.Id;
                    result.CreatedAt = item.CreatedAt;
                    //---------User-------------------///
                    var user = context.Users.FirstOrDefault(x => x.Id == item.UserId);
                    result.User = user;
                    //-----------------Product-------------------///
                    var product = context.Products.FirstOrDefault(x => x.Id == item.ProductId);
                    result.Product = product;

                    resultList.Add(result);
                }

                return Ok(resultList);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("RegisterUser")]
        public IActionResult RegisterUser([FromBody] Entities.User user)
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
        public IActionResult LoginUser([FromBody] Models.UserModel user)
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
                            new Claim("id", query.Id.ToString()),
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

        [HttpPost("InsertCartItem/{userid}/{productid}")]
        public IActionResult InsertCartItem(int userid, int productid)
        {
            try
            {
                string result = "not inserted";
                var cartCount = context.Carts.Count(x => x.Ordered == "false" && x.UserId == userid);
                if (cartCount == 0)
                {
                    var insertCart = new Cart();
                    insertCart.UserId = userid;
                    insertCart.Ordered = "false";
                    insertCart.OrderedOn = "";
                    context.Carts.Add(insertCart);
                    context.SaveChanges();
                }

                var cartId = context.Carts.FirstOrDefault(x => x.UserId == userid && x.Ordered == "false").Id;
                if (cartId != null)
                {
                    var insertCartItem = new CartItem();
                    insertCartItem.CartId = cartId;
                    insertCartItem.ProductId = productid;
                    context.CartItems.Add(insertCartItem);
                    context.SaveChanges();
                    result = "inserted";
                }

                return Ok(result);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpGet("GetActiveCartOfUser/{id}")]
        public IActionResult GetActiveCartOfUser(int id)
        {
            try
            {
                var result = new CartViewModel();
                var count = context.Carts.Count(x => x.UserId == id && x.Ordered == "false");
                if (count == 0) { return Ok(result); }

                var cartId = context.Carts.FirstOrDefault(x => x.UserId == id && x.Ordered == "false").Id;
                if (cartId != null)
                {
                    var user = context.Users.FirstOrDefault(x => x.Id == id);
                    var listCart = context.CartItems.Where(x => x.CartId == cartId).ToList();
                    foreach (var item in listCart)
                    {
                        var product = context.Products.FirstOrDefault(x => x.Id == item.ProductId);
                        var category = context.ProductCategories.FirstOrDefault(x => x.Id == product.CategoryId);
                        var offer = context.Offers.FirstOrDefault(x => x.Id == product.OfferId);
                        var cart = new CartItemViewModel();
                        cart.product = product;
                        cart.product.ProductCategory = category;
                        cart.product.Offer = offer;
                        result.CartItems.Add(cart);
                    }
                    result.Id = cartId;
                    result.User = user;
                    result.Ordered = false;
                    result.OrderedOn = "";
                }

                return Ok(result);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        //[HttpGet("GetAllPreviousCartsOfUser/{id}")]
        //public IActionResult GetAllPreviousCartsOfUser(int id)
        //{
        //    try
        //    {
        //        var result = new CartViewModel();
        //        var resultList = new List<CartViewModel>();
        //        var cartList = context.Carts.FirstOrDefault(x => x.UserId == id && x.Ordered == "true").Id;
        //        foreach (var m in cartList)
        //        {
        //            var cartItemList = context.CartItems.Where(x => x.CartId == m.Id).ToList();
        //            foreach (var item in cartItemList)
        //            {
        //                var cartItem = new CartItemViewModel();
        //                var product = context.Products.FirstOrDefault(x => x.Id == item.ProductId);
        //                var category = context.ProductCategories.FirstOrDefault(x => x.Id == product.CategoryId);
        //                var offer = context.Offers.FirstOrDefault(x => x.Id == product.OfferId);
        //                cartItem.product = product;
        //                cartItem.product.ProductCategory = category;
        //                cartItem.product.Offer = offer;
        //                result.CartItems.Add(cartItem);
        //            }
        //            resultList.Add(result);
        //        }
        //        return Ok(resultList);
        //    }
        //    catch (Exception ex) { return BadRequest(ex); }
        //}
        //[HttpGet("GetAllPreviousCartsOfUser/{id}")]
        //public IActionResult GetAllPreviousCartsOfUser(int id)
        //{
        //    try
        //    {
        //        var result = new CartViewModel();
              
        //            var cartIdTrue = context.Carts.FirstOrDefault(x => x.UserId == id && x.Ordered == "true").Id;
                
        //        var cartItemList = context.CartItems.Where(x => x.CartId == cartIdTrue).ToList();
        //        if (cartItemList.Count > 0)
        //        {
        //            foreach (var item in cartItemList)
        //            {
        //                var cartItem = new CartItemViewModel();
        //                var product = context.Products.FirstOrDefault(x => x.Id == item.ProductId);
        //                var category = context.ProductCategories.FirstOrDefault(x => x.Id == product.CategoryId);
        //                var offer = context.Offers.FirstOrDefault(x => x.Id == product.OfferId);
        //                cartItem.product = product;
        //                cartItem.product.ProductCategory = category;
        //                cartItem.product.Offer = offer;
        //                result.CartItems.Add(cartItem);
        //            }
        //        }

        //        if (cartIdTrue != null)
        //            result.Id = cartIdTrue;
        //        var user = context.Users.FirstOrDefault(x => x.Id == id);

        //        if (user != null)
        //            result.User = user;

        //        var cart = context.Carts.FirstOrDefault(x => x.UserId == id);
        //        if (cart != null)
        //        {
        //            result.Ordered = bool.Parse(cart.Ordered);
        //            result.OrderedOn = cart.OrderedOn;
        //        }

        //        return Ok(result);
        //    }
        //    catch (Exception ex) { return BadRequest(ex); }
        //}

        [HttpGet("GetAllPreviousCartsOfUser/{id}")]
        public IActionResult GetAllPreviousCartsOfUser(int id)
        {
            var result = dataAccess.GetAllPreviousCartsOfUser(id);
            return Ok(result);
        }
    }
}
