using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

    public async Task<IEnumerable<User>> GetAllUser()
    {
        var users = await _dbContext.user.ToListAsync();
        return users;
    }

    public async Task<User> GetUser(string userId)
    {
        var user = await _dbContext.user.FindAsync(userId);
        return user;
    }

    public async Task<IEnumerable<User>> GetUsersInDepartment(string departmentId)
    {
        var users = await _dbContext.user.Where(u => u.department_id == departmentId).ToListAsync();
        return users;
    }

    public async Task<IEnumerable<User>> GetUsersWithRole(string roleId)
    {
        var users = await _dbContext.user.Where(u => u.role_id == roleId).ToListAsync();
        return users;
    }

    public async Task<User> UpdateUser(string userId, User user)
    {
        var userExists = await _dbContext.user.FindAsync(userId);
        if (userExists != null)
        {
            _dbContext.user.Remove(userExists);
            await _dbContext.SaveChangesAsync();
            await _dbContext.AddAsync(user);
        }
        return user;
    }

    public async Task<bool> ChangePassword(string userId, string oldPassword, string newPassword)
    {
        var user = await _dbContext.user.FindAsync(userId);
        if (!VerifyPassword(userId, oldPassword, user!.password_hash))
        {
            return false;
        }
        user.password_hash = HashPassword(userId, newPassword);
        var result = await _dbContext.SaveChangesAsync();
        return result == 1;
    }
    private string HashPassword(string userId, string password)
    {
        var user = new IdentityUser { UserName = userId };
        var passwordHasher = new PasswordHasher<IdentityUser>();
        return passwordHasher.HashPassword(user, password);
    }

    private bool VerifyPassword(string userId, string password, string hashedPassword)
    {
        var user = new IdentityUser { UserName = userId };
        var passwordHasher = new PasswordHasher<IdentityUser>();
        var result = passwordHasher.VerifyHashedPassword(user, hashedPassword, password);
        return result == PasswordVerificationResult.Success;
    }
}