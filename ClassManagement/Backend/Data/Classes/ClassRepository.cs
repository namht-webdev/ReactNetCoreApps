using ClassManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClassManagement.Data;
class ClassRepository : IClassRepository
{
    private readonly ClassManagementDbContext _dbContext;

    public ClassRepository(ClassManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Task<bool> CreateAsync(Class myclass)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> ReadAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> UpdateAsync(int id, Class myclass)
    {
        throw new NotImplementedException();
    }
}

