using E_CommerceAPI.Entities;
using E_CommerceAPI.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceAPI.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly EcommerceContext _context;
        public ProductService(EcommerceContext context)
        {
            _context = context;
        }
        public Task<Entities.Product> Add(Entities.Product model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(Entities.Product model)
        {
            try
            {
                _context.Products.Remove(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Entities.Product>> GetList()
        {
            try
            {
                List<Product> list = new List<Product>();
                list = await _context.Products.ToListAsync();

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Entities.Product> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Entities.Product> Update(Entities.Product model)
        {
            try
            {
                _context.Products.Update(model);
                await _context.SaveChangesAsync();
                return model;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
