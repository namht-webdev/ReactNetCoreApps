using Microsoft.EntityFrameworkCore;
using CompanyManagement.Models;
namespace CompanyManagement.Data;

public class RoleRepository : IRoleRepository
{
    private readonly CompanyManagementDbContext _dbcontext;
    public RoleRepository(CompanyManagementDbContext dbContext) => _dbcontext = dbContext;
    public async Task<bool> CreateRole(Role role)
    {
        var roleExists = await _dbcontext.role.FindAsync(role.role_id);
        if (roleExists != null) return false;
        await _dbcontext.role.AddAsync(role);
        var result = await _dbcontext.SaveChangesAsync();
        return result == 1;
    }

    public async Task<bool> DeleteRole(string roleId)
    {
        var roleExists = await _dbcontext.role.FindAsync(roleId);
        if (roleExists == null) return false;
        _dbcontext.Remove(roleExists);
        var result = await _dbcontext.SaveChangesAsync();
        return result == 1;
    }

    public async Task<IEnumerable<Role>> GetRole()
    {
        var roles = await _dbcontext.role.ToListAsync();
        return roles == null ? Enumerable.Empty<Role>() : roles;
    }
    public async Task<Role> GetOneRole(string roleId)
    {
        var role = await _dbcontext.role.FindAsync(roleId);
        return role;
    }

    public async Task<Role> UpdateRole(string roleId, Role role)
    {
        var roleExists = await _dbcontext.role.FindAsync(roleId);
        if (roleExists != null)
        {
            roleExists.role_name = role.role_name;
            await _dbcontext.SaveChangesAsync();
        }
        return roleExists;
    }
}