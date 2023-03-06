using E_CommerceAPI.Entities;

namespace E_CommerceAPI.Services.Contract
{
    public interface IProductService
    {
        Task<List<Product>> GetList();
        Task<Product> GetProductById(int id);
        Task<Product> Add(Product model);
        Task<Product> Update(Product model);
        Task<bool> Delete(Product model);
    }
}
