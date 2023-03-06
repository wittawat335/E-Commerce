using E_CommerceAPI.Entities;

namespace E_CommerceAPI.Services.Contract
{
    public interface IPaymentService
    {
        Task<List<Payment>> GetList();
        Task<Payment> GetProductById(int id);
        Task<Payment> Add(Payment model);
        Task<Payment> Update(Payment model);
        Task<bool> Delete(Payment model);
    }
}
