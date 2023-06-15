using System.Collections;
using ClassManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassManagement.Data;
class SubjectRepository : ISubjectRepository
{
    private readonly ClassManagementDbContext _dbContext;

    public SubjectRepository(ClassManagementDbContext dbContext) => _dbContext = dbContext;
    public async Task<bool> CreateSubjectAsync(Subject Subject)
    {
        var subject = await (from s in _dbContext.Subject where s.SubjectId == Subject.SubjectId select s).FirstOrDefaultAsync();
        if (subject != null) return false;
        await _dbContext.Subject.AddAsync(new Subject()
        {
            SubjectId = Subject.SubjectId,
            SubjectName = Subject.SubjectName
        });
        int res = _dbContext.SaveChanges();
        return res == 1;
    }

    public async Task<bool> DeleteSubjectAsync(string SubjectId)
    {
        var subject = await (from s in _dbContext.Subject where s.SubjectId == SubjectId select s).FirstOrDefaultAsync();
        if (subject == null) return false;
        _dbContext.Subject.Remove(subject);
        int res = await _dbContext.SaveChangesAsync();
        return res == 1;
    }

    public async Task<Subject> ReadSubjectAsync(string SubjectId)
    {
        var subject = await (from s in _dbContext.Subject where s.SubjectId == SubjectId select s).FirstOrDefaultAsync();
        return subject;
    }

    public async Task<IEnumerable<Subject>> ReadSubjectsAsync()
    {
        return await _dbContext.Subject.ToListAsync();
    }

    public async Task<Subject> UpdateSubjectAsync(string SubjectId, Subject Subject)
    {
        var subject = await (from s in _dbContext.Subject where s.SubjectId == SubjectId select s).FirstOrDefaultAsync();
        if (subject != null)
        {
            subject.SubjectName = Subject.SubjectName;
            await _dbContext.SaveChangesAsync();
        }
        return subject;
    }
}

