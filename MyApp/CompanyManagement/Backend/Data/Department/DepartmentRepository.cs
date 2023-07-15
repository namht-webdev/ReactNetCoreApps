using Microsoft.EntityFrameworkCore;
using CompanyManagement.Models;
namespace CompanyManagement.Data;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly CompanyManagementDbContext _dbcontext;
    public DepartmentRepository(CompanyManagementDbContext dbContext) => _dbcontext = dbContext;
    public async Task<bool> Add(Department department)
    {
        var departmentExists = await _dbcontext.department.FindAsync(department.department_id);
        if (departmentExists != null) return false;
        await _dbcontext.department.AddAsync(department);
        var result = await _dbcontext.SaveChangesAsync();
        return result == 1;
    }

    public async Task<bool> Delete(string departmentId)
    {
        var departmentExists = await _dbcontext.department.FindAsync(departmentId);
        if (departmentExists == null) return false;
        _dbcontext.Remove(departmentExists);
        var result = await _dbcontext.SaveChangesAsync();
        return result == 1;
    }

    public async Task<IEnumerable<Department>> GetAll()
    {
        var departments = await _dbcontext.department.ToListAsync();
        return departments == null ? Enumerable.Empty<Department>() : departments;
    }

    public async Task<Department> Update(string departmentId, Department department)
    {
        var departmentExists = await _dbcontext.department.FindAsync(departmentId);
        if (departmentExists != null)
        {
            departmentExists.department_name = department.department_name;
            departmentExists.floor = department.floor;
            await _dbcontext.SaveChangesAsync();
        }
        return departmentExists;
    }
    public async Task<Department> GetOne(string departmentId)
    {
        var departmentExists = await _dbcontext.department.FindAsync(departmentId);
        return departmentExists;
    }

}