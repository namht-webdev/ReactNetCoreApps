using CompanyManagement.Models;
namespace CompanyManagement.Data;
public interface ILevelRepository
{
    Task<bool> Add(Level level);
    Task<Level> Update(string levelId, Level level);
    Task<IEnumerable<Level>> GetAll();
    Task<Level> GetOne(string levelId);
    Task<bool> Delete(string levelId);
}