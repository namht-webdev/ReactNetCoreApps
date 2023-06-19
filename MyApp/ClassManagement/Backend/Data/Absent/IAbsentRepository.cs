using System.Collections;
using ClassManagement.Models;
namespace ClassManagement.Data;
public interface IAbsentRepository
{
    Task<bool> CreateAbsentAsync(Absent Absent);
    Task<IEnumerable<Absent>> ReadClassAbsentAsync(Absent Absent);
    Task<Absent> UpdateAbsentAsync(string SubjectId, string StudentId, DateTime DateAbsent, Absent AbsentNew);
    Task<bool> DeleteAbsentAsync(Absent Absent);
}