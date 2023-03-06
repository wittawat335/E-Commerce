using E_CommerceAPI.Entities;
using E_CommerceAPI.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceAPI.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly EcommerceContext _context;
        public UserService(EcommerceContext context)
        {
            _context = context;
        }
        public async Task<User> Add(User model)
        {
            try
            {
                _context.Users.Add(model);
                await _context.SaveChangesAsync();

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(User model)
        {
            try
            {
                _context.Users.Remove(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<User>> GetList()
        {
            try 
            { 
                List<User> list = new List<User>();
                list = await _context.Users.ToListAsync();

                return list;
            }
            catch (Exception ex) 
            {
                throw ex; 
            }
        }

        public async Task<User> GetProductById(int id)
        {
            try
            {
                User? user = new User();
                user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

                return user;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> Update(User model)
        {
            try
            {
                _context.Users.Update(model);
                await _context.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
