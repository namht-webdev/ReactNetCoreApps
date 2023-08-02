using System.Collections;
using ClassManagement.Models;
namespace ClassManagement.Data;
public interface ISubjectRepository
{
    Task<bool> CreateSubjectAsync(Subject Subject);
    Task<Subject> ReadSubjectAsync(string SubjectId);
    Task<IEnumerable<Subject>> ReadSubjectsAsync();
    Task<Subject> UpdateSubjectAsync(string SubjectId, Subject Subject);
    Task<bool> DeleteSubjectAsync(string SubjectId);
}