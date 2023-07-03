using CompanyManagement.Models;
public interface IUserRole
{
    Task<bool> CreateRole(Role role);
    Task<IEnumerable<Role>> GetRole();
    Task<Role> UpdateRole(string roldId, Role role);
    Task<bool> DeleteRole(string roldId);
}