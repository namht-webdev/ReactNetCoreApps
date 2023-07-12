using Microsoft.EntityFrameworkCore;
using CompanyManagement.Data;
using CompanyManagement.Models;

public class LevelRepository : ILevelRepository
{
    private readonly CompanyManagementDbContext _dbContext;
    public LevelRepository(CompanyManagementDbContext dbContext) => _dbContext = dbContext;
    public async Task<bool> Create(Level level)
    {
        var levelExists = await _dbContext.level.FindAsync(level.level_id);
        if (levelExists != null) return false;
        await _dbContext.level.AddAsync(level);
        var result = await _dbContext.SaveChangesAsync();
        return result == 1;
    }

    public async Task<bool> Delete(string levelId)
    {
        var levelExists = await _dbContext.level.FindAsync(levelId);
        if (levelExists == null) return false;
        _dbContext.level.Remove(levelExists);
        var resutl = await _dbContext.SaveChangesAsync();
        return resutl == 1;
    }

    public async Task<IEnumerable<Level>> GetAll()
    {
        var levels = await _dbContext.level.ToListAsync();
        return levels;
    }

    public async Task<Level> GetOne(string levelId)
    {
        var level = await _dbContext.level.FindAsync(levelId);
        return level;
    }

    public async Task<Level> Update(string levelId, Level level)
    {
        var levelExists = await _dbContext.level.FindAsync(levelId);
        if (levelExists != null)
        {
            levelExists.level_name = level.level_name;
            await _dbContext.SaveChangesAsync();
        }
        return levelExists;
    }
}