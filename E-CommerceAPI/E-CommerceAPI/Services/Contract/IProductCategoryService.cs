using E_CommerceAPI.Entities;

namespace E_CommerceAPI.Services.Contract
{
    public interface IProductCategoryService
    {
        Task<List<ProductCategory>> GetList();
        Task<ProductCategory> GetProductById(int id);
        Task<ProductCategory> Add(ProductCategory model);
        Task<ProductCategory> Update(ProductCategory model);
        Task<bool> Delete(ProductCategory model);
    }
}
