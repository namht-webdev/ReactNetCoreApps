using System.Collections;
using ClassManagement.Models;
namespace ClassManagement.Data;
public interface IStudentScoreRepository
{
    Task<bool> CreateStudentScoreAsync(StudentScore StudentScore);
    Task<ScoreOneSubjectViewModel> ReadScoreOneSubjectAsync(string SubjectId, string StudentId);
    Task<ScoreAllSubjectViewModel> ReadScoreAllSubjectAsync(string StudentId);

    Task<IEnumerable<ScoreOneSubjectViewModel>> ReadClassStudentScoreAsync(string ClassId);
    Task<StudentScore> UpdateStudentScoreAsync(string SubjectId, string StudentId, double Score);
    Task<bool> DeleteStudentScoreAsync(string SubjectId, string StudentId);
}