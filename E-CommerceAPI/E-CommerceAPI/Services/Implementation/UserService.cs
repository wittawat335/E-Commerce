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
        public Task<User> Add(User model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(User model)
        {
            throw new NotImplementedException();
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

        public Task<User> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(User model)
        {
            throw new NotImplementedException();
        }
    }
}
