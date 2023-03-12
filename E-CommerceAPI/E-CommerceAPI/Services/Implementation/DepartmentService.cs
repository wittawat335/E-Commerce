using E_CommerceAPI.Entities;
using E_CommerceAPI.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceAPI.Services.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly EcommerceContext _context;
        public DepartmentService(EcommerceContext context)
        {
            _context = context;
        }
        public Task<Department> Add(Department model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Department model)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Department>> GetList()
        {

            try
            {
                List<Department> list = new List<Department>();
                list = await _context.Departments.ToListAsync();

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Department> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Department> Update(Department model)
        {
            throw new NotImplementedException();
        }
    }
}
