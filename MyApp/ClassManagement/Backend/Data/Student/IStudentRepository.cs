using ClassManagement.Models;
namespace ClassManagement.Data;
public interface IStudentRepository
{
    Task<bool> CreateAsync(Student Student);
    Task<Student> ReadStudentAsync(int StudentId);
    Task<IEnumerable<Student>> ReadStudentsAsync();
    Task<Student> UpdateAsync(int StudentId, Student Student);
    Task<bool> DeleteAsync(int StudentId);
}