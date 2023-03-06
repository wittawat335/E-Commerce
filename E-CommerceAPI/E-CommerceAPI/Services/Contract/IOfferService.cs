using E_CommerceAPI.Entities;

namespace E_CommerceAPI.Services.Contract
{
    public interface IOfferService
    {
        Task<List<Offer>> GetList();
        Task<Offer> GetProductById(int id);
        Task<Offer> Add(Offer model);
        Task<Offer> Update(Offer model);
        Task<bool> Delete(Offer model);
    }
}
