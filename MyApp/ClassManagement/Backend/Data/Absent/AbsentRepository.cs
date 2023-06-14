using System.Collections;
using ClassManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClassManagement.Data;
class AbsentRepository : IAbsentRepository
{
    public Task<bool> CreateAsync(Absent Absent)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Absent Absent)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection> ReadAsync(int? StudentId, int? SubjectId, DateTime? DateAbsent)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection> UpdateAsync(Absent AbsentOld, Absent AbsentNew)
    {
        throw new NotImplementedException();
    }
}

