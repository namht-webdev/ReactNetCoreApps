using CompanyManagement.Models;

namespace CompanyManagement.Data;
public interface IUserRepository
{
    Task<bool> CreateUser(User user);
    Task<User> GetUser(string userId);
    Task<IEnumerable<User>> GetAllUser();
    Task<IEnumerable<User>> GetUsersWithRole(string roleId);
    Task<IEnumerable<User>> GetUsersInDepartment(string departmentId);
    Task<User> UpdateUser(string userId, User user);
    Task<bool> ChangePassword(string userId, string oldPassword, string newPassword);
    Task<bool> UserSoftDelete(string userId);
    Task<bool> UserHardDelete(string userId);
}