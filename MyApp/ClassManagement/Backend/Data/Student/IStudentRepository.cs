using ClassManagement.Models;
namespace ClassManagement.Data;
public interface IStudentRepository
{
    Task<bool> CreateAsync(Student Student);
    Task<Student> ReadStudentAsync(string StudentId);
    Task<IEnumerable<Student>> ReadStudentsAsync();
    Task<Student> UpdateAsync(string StudentId, Student Student);
    Task<bool> DeleteAsync(string StudentId);
}