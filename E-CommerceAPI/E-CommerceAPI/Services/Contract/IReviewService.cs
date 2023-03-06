using E_CommerceAPI.Entities;

namespace E_CommerceAPI.Services.Contract
{
    public interface IReviewService
    {
        Task<List<Review>> GetList();
        Task<Review> GetProductById(int id);
        Task<Review> Add(Review model);
        Task<Review> Update(Review model);
        Task<bool> Delete(Review model);
    }
}
