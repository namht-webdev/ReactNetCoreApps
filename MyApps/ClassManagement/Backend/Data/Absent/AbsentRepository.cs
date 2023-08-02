using System.Collections;
using ClassManagement.Models;
using Microsoft.EntityFrameworkCore;
namespace ClassManagement.Data;
class AbsentRepository : IAbsentRepository
{
    private readonly ClassManagementDbContext _dbContext;
    public AbsentRepository(ClassManagementDbContext dbContext) => _dbContext = dbContext;
    public async Task<bool> CreateAbsentAsync(Absent Absent)
    {
        var absent = await _dbContext.Absent.Where(absent => (absent.SubjectId == Absent.SubjectId && absent.StudentId == Absent.StudentId && absent.DateAbsent == Absent.DateAbsent)).FirstOrDefaultAsync();
        if (absent != null) return false;
        await _dbContext.Absent.AddAsync(Absent);
        int result = await _dbContext.SaveChangesAsync();
        return result == 1;
    }

    public async Task<bool> DeleteAbsentAsync(Absent Absent)
    {
        var absent = await _dbContext.Absent.Where(absent => (absent.SubjectId == Absent.SubjectId && absent.StudentId == Absent.StudentId && absent.DateAbsent == Absent.DateAbsent)).FirstOrDefaultAsync();
        if (absent == null) return false;
        _dbContext.Absent.Remove(absent);
        int result = await _dbContext.SaveChangesAsync();
        return result == 1;
    }

    public async Task<IEnumerable<Absent>> ReadClassAbsentAsync(Absent Absent)
    {
        var absent = await _dbContext.Absent.FromSql<Absent>(@$"EXEC ReadAbsents {Absent.SubjectId},
                                                                                {Absent.StudentId},
                                                                                {Absent.IsConfirmed},
                                                                                {Absent.DateAbsent}")
                                                                                .ToListAsync();
        if (absent == null) return Enumerable.Empty<Absent>();
        return absent;
    }

    public async Task<Absent> UpdateAbsentAsync(string SubjectId, string StudentId, DateTime DateAbsent, Absent Absent)
    {
        var absent = await _dbContext.Absent.Where(absent => absent.SubjectId == Absent.SubjectId && absent.StudentId == Absent.StudentId && absent.DateAbsent == Absent.DateAbsent).FirstOrDefaultAsync();
        if (absent == null) return absent;
        if (SubjectId != Absent.SubjectId || Absent.StudentId != StudentId || Absent.DateAbsent == DateAbsent)
        {
            await DeleteAbsentAsync(Absent);
            await CreateAbsentAsync(Absent);
        }
        else
        {
            absent.IsConfirmed = Absent.IsConfirmed;
            await _dbContext.SaveChangesAsync();
        }
        return Absent;
    }
}

