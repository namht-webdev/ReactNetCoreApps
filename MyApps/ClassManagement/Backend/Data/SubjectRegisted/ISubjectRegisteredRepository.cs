using ClassManagement.Models;

public interface ISubjectRegisteredRepository
{
    Task<bool> CreateSubjectRegisteredAsync(SubjectRegistered SubjectRegistered);
    Task<bool> DeleteSubjectRegisteredAsync(string SubjectId, int Semester, int Year);
    Task<IEnumerable<SubjectRegistered>> ReadSubjectsRegisteredAsync(SubjectRegistered SubjectRegistered);
    Task<SubjectRegistered> UpdateSubjectRegisteredAsync(string SubjectId, int Semester, int Year, SubjectRegistered SubjectRegistered);
}