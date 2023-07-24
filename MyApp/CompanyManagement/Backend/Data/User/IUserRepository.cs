using CompanyManagement.Models;

namespace CompanyManagement.Data;
public interface IUserRepository
{
    Task<bool> Add(User user);
    Task<User> GetOne(string userId);
    Task<IEnumerable<User>> GetAll();
    Task<IEnumerable<User>> GetUsersWithRole(string roleId);
    Task<IEnumerable<User>> GetUsersInDepartment(string departmentId);
    Task<User> Update(string userId, User user);
    Task<bool> UpdateAvatar(string userId, string imageName);
    Task<bool> ChangePassword(string userId, string oldPassword, string newPassword);
    Task<bool> SoftDelete(string userId);
    Task<bool> HardDelete(string userId);
}