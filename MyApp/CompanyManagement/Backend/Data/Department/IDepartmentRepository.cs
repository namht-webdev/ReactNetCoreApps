using CompanyManagement.Models;
public interface IDepartmentRepository
{
    Task<bool> CreateDepartment(Department department);
    Task<IEnumerable<Department>> GetDepartment();
    Task<Department> UpdateDepartment(string departmentId, Department department);
    Task<bool> DeleteDepartment(string roldId);
}