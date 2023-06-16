using ClassManagement.Models;
using Microsoft.EntityFrameworkCore;
namespace ClassManagement.Data;
public class SubjectRegisteredRepository : ISubjectRegisteredRepository
{
    private readonly ClassManagementDbContext _dbContext;
    public SubjectRegisteredRepository(ClassManagementDbContext dbContext) => _dbContext = dbContext;
    public async Task<bool> CreateSubjectRegisteredAsync(SubjectRegistered SubjectRegistered)
    {
        var subject = await _dbContext.SubjectRegistered.Where(sr => (sr.SubjectId == SubjectRegistered.SubjectId && sr.Semester == SubjectRegistered.Semester) || sr.TeacherId == SubjectRegistered.TeacherId).FirstOrDefaultAsync();
        if (subject != null) return false;
        await _dbContext.SubjectRegistered.AddAsync(SubjectRegistered);
        int result = await _dbContext.SaveChangesAsync();
        return result == 1;
    }

    public async Task<bool> DeleteSubjectRegisteredAsync(string SubjectId, int Semester, int Year)
    {
        var subject = await _dbContext.SubjectRegistered.Where(sr => sr.SubjectId == SubjectId && sr.Semester == Semester && sr.Year == Year).FirstOrDefaultAsync();
        if (subject == null) return false;
        _dbContext.SubjectRegistered.Remove(subject);
        int result = await _dbContext.SaveChangesAsync();
        return result == 1;
    }

    public async Task<IEnumerable<SubjectRegistered>> ReadSubjectsRegisteredAsync(SubjectRegistered SubjectRegistered)
    {
        var sr = await _dbContext.SubjectRegistered.FromSql<SubjectRegistered>(@$"EXEC ReadSubjectsRegistered {SubjectRegistered.ClassId},
                                                                                                            {SubjectRegistered.SubjectId},
                                                                                                            {SubjectRegistered.TeacherId},
                                                                                                            {SubjectRegistered.Semester},
                                                                                                            {SubjectRegistered.Year}")
                                                                                                            .ToListAsync();
        if (sr == null) return Enumerable.Empty<SubjectRegistered>();
        return sr;
    }

    public async Task<SubjectRegistered> UpdateSubjectRegisteredAsync(string SubjectId, int Semester, int Year, SubjectRegistered SubjectRegistered)
    {
        var subject = await _dbContext.SubjectRegistered.Where(sr => sr.SubjectId == SubjectId && sr.Semester == Semester && sr.Year == Year).FirstOrDefaultAsync();
        if (subject == null) return subject;
        if (SubjectId != SubjectRegistered.SubjectId || SubjectRegistered.Semester != Semester || SubjectRegistered.Year == Year)
        {
            await DeleteSubjectRegisteredAsync(SubjectId, Semester, Year);
            await CreateSubjectRegisteredAsync(SubjectRegistered);
        }
        else
        {
            subject.ClassId = SubjectRegistered.ClassId;
            subject.TeacherId = SubjectRegistered.TeacherId;
            await _dbContext.SaveChangesAsync();
        }
        return SubjectRegistered;
    }
}