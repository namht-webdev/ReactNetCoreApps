using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using CompanyManagement.Data;
using CompanyManagement.Models;

public class ListRepository : IListRepository
{
    private readonly CompanyManagementDbContext _dbContext;
    public ListRepository(CompanyManagementDbContext dbContext) => _dbContext = dbContext;
    public async Task<bool> AddOne(string tableName, ICollection<Dictionary<string, string>> data)
    {
        //await _dbContext.Database.OpenConnectionAsync();
        throw new NotImplementedException();
    }

    public Task<bool> DeleteOne(string tableName, ICollection<Dictionary<string, string>> data)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetMany(string tableName, ICollection<Dictionary<string, string>> data, Condition? conditions)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetOne(string tableName, ICollection<Dictionary<string, string>> data)
    {
        throw new NotImplementedException();
    }

    public Task<string> UpdateOne(string tableName, ICollection<Dictionary<string, string>> data)
    {
        throw new NotImplementedException();
    }
}