using E_CommerceAPI.Entities;

namespace E_CommerceAPI.Services.Contract
{
    public interface ICartItemService
    {
        Task<List<CartItem>> GetList();
        Task<CartItem> GetProductById(int id);
        Task<CartItem> Add(CartItem model);
        Task<CartItem> Update(CartItem model);
        Task<bool> Delete(CartItem model);
    }
}
