using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using E_CommerceAPI.Services.Contract;
using E_CommerceAPI.Utilities;
using E_CommerceAPI.ViewModels;
using E_CommerceAPI.Common;
using E_CommerceAPI.Services.Implementation;
using E_CommerceAPI.Entities;
using System.Collections.Generic;

namespace E_CommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        public UsersController(IConfiguration configuration, IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _configuration = configuration;
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            ReponseApi<List<UserViewModel>> _response = new ReponseApi<List<UserViewModel>>();
            try
            {
                var model = await _userService.GetList();
                if (model.Count > 0)
                {
                    var list = _mapper.Map<List<UserViewModel>>(model);
                    _response = new ReponseApi<List<UserViewModel>> { 
                        Status = Constants.Status.True, 
                        StatusMessage = Constants.StatusMessage.Success,
                        Value = list 
                    };
                }
                else
                {
                    _response = new ReponseApi<List<UserViewModel>> { 
                        Status = Constants.Status.False, 
                        StatusMessage = Constants.StatusMessage.Faile };
                }

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ReponseApi<List<UserViewModel>> { Status = Constants.Status.False, StatusMessage = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        // GET: api/Users/5
        //    [HttpGet("{id}")]
        //    public async Task<ActionResult<User>> GetUser(int id)
        //    {
        //      if (_context.Users == null)
        //      {
        //          return NotFound();
        //      }
        //        var user = await _context.Users.FindAsync(id);

        //        if (user == null)
        //        {
        //            return NotFound();
        //        }

        //        return user;
        //    }

        //    // PUT: api/Users/5
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutUser(int id, User user)
        //    {
        //        if (id != user.Id)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(user).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UserExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return NoContent();
        //    }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser(UserViewModel user)
        {
            var _response = new ReponseApi<UserViewModel>();
            try
            {
                var model = _mapper.Map<User>(user);
                var created = await _userService.Add(model);
                if (created.Id != 0) 
                {
                    _response = new ReponseApi<UserViewModel> { 
                        Status = Constants.Status.True, 
                        StatusMessage = Constants.StatusMessage.Success, 
                        Value = _mapper.Map<UserViewModel>(created) 
                    };
                }

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ReponseApi<UserViewModel> { Status = Constants.Status.False, StatusMessage = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        //    // DELETE: api/Users/5
        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> DeleteUser(int id)
        //    {
        //        if (_context.Users == null)
        //        {
        //            return NotFound();
        //        }
        //        var user = await _context.Users.FindAsync(id);
        //        if (user == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.Users.Remove(user);
        //        await _context.SaveChangesAsync();

        //        return NoContent();
        //    }

        //    private bool UserExists(int id)
        //    {
        //        return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        //    }
    }
}
