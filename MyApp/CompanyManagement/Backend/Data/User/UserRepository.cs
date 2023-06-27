using CompanyManagement.Data;
using CompanyManagement.Models;

public class UserRepository : IUserRepository
{
    private readonly CompanyManagementDbContext _dbContext;

    public UserRepository(CompanyManagementDbContext dbContext) => _dbContext = dbContext;
    public async Task<bool> CreateUser(User user)
    {
        var userExists = await _dbContext.user.FindAsync(user.user_id);
        if (userExists != null) return false;
        await _dbContext.user.AddAsync(user);
        var result = await _dbContext.SaveChangesAsync();
        return result == 1;
    }

    public Task<bool> DeleteUser(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllUser(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUser(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetUserInDepartment(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetUserWithRole(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateUser(string userId, User user)
    {
        throw new NotImplementedException();
    }
}