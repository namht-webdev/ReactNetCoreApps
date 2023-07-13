using CompanyManagement.Models;
namespace CompanyManagement.Data;
public interface IListRepository
{
    Task<bool> AddOne(string tableName, ICollection<Dictionary<string, string>> data);
    Task<string> GetOne(string tableName, ICollection<Dictionary<string, string>> data);
    Task<string> GetMany(string tableName, ICollection<Dictionary<string, string>> data, Condition? conditions);
    Task<string> UpdateOne(string tableName, ICollection<Dictionary<string, string>> data);
    Task<bool> DeleteOne(string tableName, ICollection<Dictionary<string, string>> data);
}