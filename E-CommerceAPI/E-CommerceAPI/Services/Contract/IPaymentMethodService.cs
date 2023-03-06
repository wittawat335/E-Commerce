using E_CommerceAPI.Entities;

namespace E_CommerceAPI.Services.Contract
{
    public interface IPaymentMethodService
    {
        Task<List<PaymentMethod>> GetList();
        Task<PaymentMethod> GetProductById(int id);
        Task<PaymentMethod> Add(PaymentMethod model);
        Task<PaymentMethod> Update(PaymentMethod model);
        Task<bool> Delete(PaymentMethod model);
    }
}
