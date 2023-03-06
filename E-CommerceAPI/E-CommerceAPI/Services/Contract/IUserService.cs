using E_CommerceAPI.Entities;

namespace E_CommerceAPI.Services.Contract
{
    public interface IUserService
    {
        Task<List<User>> GetList();
        Task<User> GetProductById(int id);
        Task<User> Add(User model);
        Task<User> Update(User model);
        Task<bool> Delete(User model);
    }
}
