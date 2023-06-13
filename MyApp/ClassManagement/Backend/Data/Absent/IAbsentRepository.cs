using Microsoft.AspNetCore.Mvc;
using ClassManagement.Models;
namespace ClassManagement.Data;
public interface IAbsentRepository
{
    Task<bool> CreateAsync(Absent Absent);
    Task<IActionResult> ReadAsync(int? StudentId, int? SubjectId, DateTime? DateAbsent);
    Task<IActionResult> UpdateAsync(Absent AbsentOld, Absent AbsentNew);
    Task<bool> DeleteAsync(Absent Absent);
}