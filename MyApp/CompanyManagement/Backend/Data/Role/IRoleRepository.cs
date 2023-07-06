using CompanyManagement.Models;
public interface IRoleRepository
{
    Task<bool> CreateRole(Role role);
    Task<IEnumerable<Role>> GetRole();
    Task<Role> GetOneRole(string roleId);
    Task<Role> UpdateRole(string roleId, Role role);
    Task<bool> DeleteRole(string roleId);
}