using System.Collections;
using ClassManagement.Models;
namespace ClassManagement.Data;
public interface IStudentScoreRepository
{
    Task<bool> CreateStudentScoreAsync(StudentScore StudentScore);
    Task<IEnumerable<StudentScore>> ReadStudentScoreAsync(string StudentId);
    Task<IEnumerable<StudentScore>> ReadClassStudentScoreAsync(string ClassId);
    Task<StudentScore> UpdateStudentScoreAsync(string SubjectId, string StudentId, DateTime DateStudentScore, StudentScore StudentScoreNew);
    Task<bool> DeleteStudentScoreAsync(string SubjectId, string StudentId);
}