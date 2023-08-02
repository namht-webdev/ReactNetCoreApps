using CompanyManagement.Models;
public interface IRoleRepository
{
    Task<bool> Add(Role role);
    Task<IEnumerable<Role>> GetAll();
    Task<Role> GetOne(string roleId);
    Task<Role> Update(string roleId, Role role);
    Task<bool> Delete(string roleId);
}