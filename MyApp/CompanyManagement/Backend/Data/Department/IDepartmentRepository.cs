using CompanyManagement.Models;
public interface IDepartmentRepository
{
    Task<bool> Add(Department department);
    Task<IEnumerable<Department>> GetAll();
    Task<Department> GetOne(string departmentId);
    Task<Department> Update(string departmentId, Department department);
    Task<bool> Delete(string departmentId);
}