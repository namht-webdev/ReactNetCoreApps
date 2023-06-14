using System.Collections;
using ClassManagement.Models;
namespace ClassManagement.Data;
public interface IAbsentRepository
{
    Task<bool> CreateAsync(Absent Absent);
    Task<ICollection> ReadAsync(int? StudentId, int? SubjectId, DateTime? DateAbsent);
    Task<ICollection> UpdateAsync(Absent AbsentOld, Absent AbsentNew);
    Task<bool> DeleteAsync(Absent Absent);
}