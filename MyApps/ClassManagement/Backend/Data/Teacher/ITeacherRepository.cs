using ClassManagement.Models;
namespace ClassManagement.Data;
public interface ITeacherRepository
{
    Task<bool> CreateTeacherAsync(Teacher Teacher);
    Task<Teacher> ReadTeacherAsync(string TeacherId);
    Task<IEnumerable<Teacher>> ReadTeachersAsync();
    Task<Teacher> UpdateTeacherAsync(string TeacherId, Teacher Teacher);
    Task<bool> DeleteTeacherAsync(string TeacherId);
}