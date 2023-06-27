using CompanyManagement.Models;

namespace CompanyManagement.Data;
public interface IUserRepository
{
    Task<bool> CreateUser(User user);
    Task<User> GetUser(string userId);
    Task<IEnumerable<User>> GetAllUser(string userId);
    Task<IEnumerable<User>> GetUserWithRole(string userId);
    Task<IEnumerable<User>> GetUserInDepartment(string userId);
    Task<bool> UpdateUser(string userId, User user);
    Task<bool> DeleteUser(string userId);
}