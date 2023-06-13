using ClassManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClassManagement.Data;
class AbsentRepository : IAbsentRepository
{
    private readonly ClassManagementDbContext _dbContext;

    public Task<bool> CreateAsync(Absent Absent)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Absent Absent)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> ReadAsync(int? StudentId, int? SubjectId, DateTime? DateAbsent)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> UpdateAsync(Absent AbsentOld, Absent AbsentNew)
    {
        throw new NotImplementedException();
    }
}

