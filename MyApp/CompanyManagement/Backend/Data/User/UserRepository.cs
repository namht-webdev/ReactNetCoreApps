using Microsoft.AspNetCore.Identity;
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
        user.password_hash = HashPassword(user.user_id, user.password_hash);
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

    private string HashPassword(string PhoneNumber, string Password)
    {
        var user = new IdentityUser { UserName = PhoneNumber };
        var passwordHasher = new PasswordHasher<IdentityUser>();
        return passwordHasher.HashPassword(user, Password);
    }

    private bool VerifyPassword(string PhoneNumber, string Password, string HashedPassword)
    {
        var user = new IdentityUser { UserName = PhoneNumber };
        var passwordHasher = new PasswordHasher<IdentityUser>();
        var result = passwordHasher.VerifyHashedPassword(user, HashedPassword, Password);
        return result == PasswordVerificationResult.Success;
    }
}