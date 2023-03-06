using E_CommerceAPI.Entities;
using E_CommerceAPI.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceAPI.Services.Implementation
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly EcommerceContext _context;
        public ProductCategoryService(EcommerceContext context)
        {
            _context = context;
        }
        public Task<Entities.ProductCategory> Add(Entities.ProductCategory model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Entities.ProductCategory model)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Entities.ProductCategory>> GetList()
        {
            try
            {
                List<ProductCategory> list = new List<ProductCategory>();
                list = await _context.ProductCategories.ToListAsync();

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Entities.ProductCategory> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Entities.ProductCategory> Update(Entities.ProductCategory model)
        {
            throw new NotImplementedException();
        }
    }
}
