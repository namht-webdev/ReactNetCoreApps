using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CompanyManagement.Data;
using CompanyManagement.Models;

public class UserRepository : IUserRepository
{
    private readonly CompanyManagementDbContext _dbContext;

    public UserRepository(CompanyManagementDbContext dbContext) => _dbContext = dbContext;

    public async Task<User> Login(string email, string password)
    {
        var userContainEmail = await _dbContext.user.FirstOrDefaultAsync(user => user.email == email);
        if (userContainEmail == null) return userContainEmail;
        var auth = VerifyPassword(userContainEmail.user_id, password, userContainEmail.password_hash);
        if (auth) return userContainEmail;
        return null;
    }
    public async Task<bool> Add(User user)
    {
        var userExists = await _dbContext.user.FindAsync(user.user_id);
        var userContainEmail = await _dbContext.user.FirstOrDefaultAsync(u => u.email == user.email);
        if (userExists != null || userContainEmail != null) return false;
        user.password_hash = HashPassword(user.user_id, user.password_hash);
        await _dbContext.user.AddAsync(user);
        var result = await _dbContext.SaveChangesAsync();
        return result == 1;
    }

    public async Task<bool> SoftDelete(string userId)
    {
        var userExists = await _dbContext.user.FindAsync(userId);
        if (userExists == null) return false;
        userExists.is_deleted = true;
        int result = await _dbContext.SaveChangesAsync();
        return result == 1;
    }

    public async Task<bool> HardDelete(string userId)
    {
        var userExists = await _dbContext.user.FindAsync(userId);
        if (userExists == null) return false;
        _dbContext.user.Remove(userExists);
        int result = await _dbContext.SaveChangesAsync();
        return result == 1;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        var users = await _dbContext.user.ToListAsync();
        return users;
    }

    public async Task<User> GetOne(string userId)
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

    public async Task<User> Update(string userId, User user)
    {
        var userExists = await _dbContext.user.FindAsync(userId);
        if (userExists != null)
        {
            _dbContext.user.Remove(userExists);
            await _dbContext.SaveChangesAsync();
            user.password_hash = HashPassword(user.user_id, user.password_hash);
            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
        return userExists;
    }
    public async Task<bool> UpdateAvatar(string userId, string imageName)
    {
        var userExists = await _dbContext.user.FindAsync(userId);
        if (userExists == null) return false;
        userExists.avatar = imageName;
        var result = await _dbContext.SaveChangesAsync();
        return result == 1;
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