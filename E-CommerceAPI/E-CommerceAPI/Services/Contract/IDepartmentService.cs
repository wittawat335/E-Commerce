using E_CommerceAPI.Entities;

namespace E_CommerceAPI.Services.Contract
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetList();
        Task<Department> GetDepartmentById(int id);
        Task<Department> Add(Department model);
        Task<Department> Update(Department model);
        Task<bool> Delete(Department model);
    }
}
