using E_CommerceAPI.Entities;

namespace E_CommerceAPI.Services.Contract
{
    public interface IOrderService
    {
        Task<List<Order>> GetList();
        Task<Order> GetProductById(int id);
        Task<Order> Add(Order model);
        Task<Order> Update(Order model);
        Task<bool> Delete(Order model);
    }
}
