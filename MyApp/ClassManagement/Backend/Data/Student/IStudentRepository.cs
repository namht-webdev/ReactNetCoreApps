using ClassManagement.Models;
namespace ClassManagement.Data;
public interface IStudentRepository
{
    Task<bool> CreateAsync(Student Student);
    Task<Student> ReadStudentAsync(string StudentId);
    Task<IEnumerable<Student>> ReadStudentsAsync();
    Task<Student> UpdateTeacherAsync(string StudentId, Student Student);
    Task<bool> DeleteTeacherAsync(string StudentId);
}