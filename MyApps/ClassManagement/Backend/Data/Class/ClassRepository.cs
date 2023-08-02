using ClassManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClassManagement.Data;
class ClassRepository : IClassRepository
{
    private readonly ClassManagementDbContext _dbContext;

    public ClassRepository(ClassManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<bool> CreateClassAsync(Class Class)
    {
        var dbClass = await _dbContext.Class.Where(c => c.ClassId == Class.ClassId).FirstOrDefaultAsync();
        if (dbClass != null) return false;

        await _dbContext.Class.AddAsync(Class);
        int result = await _dbContext.SaveChangesAsync();
        return result == 1;
    }

    public async Task<bool> DeleteClassAsync(string ClassId)
    {
        var dbClass = await _dbContext.Class.Where(c => c.ClassId == ClassId).FirstOrDefaultAsync();
        if (dbClass == null) return false;
        _dbContext.Class.Remove(dbClass);
        int result = await _dbContext.SaveChangesAsync();
        return result == 1;
    }

    public async Task<IEnumerable<Class>> ReadClassesAsync()
    {
        return await _dbContext.Class.ToListAsync();
    }

    public async Task<Class> ReadClassAsync(string ClassId)
    {
        var dbClass = await _dbContext.Class.Where(c => c.ClassId == ClassId).FirstOrDefaultAsync();
        return dbClass;
    }

    public async Task<Class> UpdateClassAsync(string ClassId, Class Class)
    {
        var dbClass = await _dbContext.Class.Where(c => c.ClassId == ClassId).FirstOrDefaultAsync();

        if (dbClass != null)
        {
            dbClass.ClassName = Class.ClassName;
            dbClass.Description = Class.Description;
            dbClass.TeacherId = Class.TeacherId;
            await _dbContext.SaveChangesAsync();
        }
        return Class;
    }
}

