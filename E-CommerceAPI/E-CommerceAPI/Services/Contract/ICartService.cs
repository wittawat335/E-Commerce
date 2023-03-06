using E_CommerceAPI.Entities;

namespace E_CommerceAPI.Services.Contract
{
    public interface ICartService
    {
        Task<List<Cart>> GetList();
        Task<Cart> GetProductById(int id);
        Task<Cart> Add(Cart model);
        Task<Cart> Update(Cart model);
        Task<bool> Delete(Cart model);
    }
}
