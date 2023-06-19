using Microsoft.EntityFrameworkCore;
using ClassManagement.Models;

namespace ClassManagement.Data;

public class StudentScoreRepository : IStudentScoreRepository
{
    private readonly ClassManagementDbContext _dbContext;
    public StudentScoreRepository(ClassManagementDbContext dbContext) => _dbContext = dbContext;
    public async Task<bool> CreateStudentScoreAsync(StudentScore StudentScore)
    {
        var student = await _dbContext.StudentScore.FirstOrDefaultAsync(s => s.StudentId == StudentScore.StudentId && s.SubjectId == StudentScore.SubjectId);
        if (student != null) return false;
        await _dbContext.StudentScore.AddAsync(StudentScore);
        int result = await _dbContext.SaveChangesAsync();
        return result == 1;
    }

    public async Task<bool> DeleteStudentScoreAsync(string SubjectId, string StudentId)
    {
        var student = await _dbContext.StudentScore.FirstOrDefaultAsync(s => s.StudentId == StudentId && s.SubjectId == SubjectId);
        if (student == null) return false;
        _dbContext.StudentScore.Remove(student);
        int result = await _dbContext.SaveChangesAsync();
        return result == 1;
    }

    public async Task<IEnumerable<StudentScore>> ReadClassStudentScoreAsync(string ClassId)
    {
        var students = await _dbContext.Student.Where(s => s.ClassId == ClassId).ToListAsync();
        //var studentScore = _dbContext.StudentScore.Select(ss => studentsIds.Contains(ss.StudentId));
        if (students == null) return Enumerable.Empty<StudentScore>();
        students.ForEach(s =>
        {
            _dbContext.Entry<Student>(s).Reference(s => s.StudentScore).Load();
        });
        return Enumerable.Empty<StudentScore>();
    }

    public Task<IEnumerable<StudentScore>> ReadStudentScoreAsync(string StudentId)
    {
        throw new NotImplementedException();
    }

    public Task<StudentScore> UpdateStudentScoreAsync(string SubjectId, string StudentId, DateTime DateStudentScore, StudentScore StudentScoreNew)
    {
        throw new NotImplementedException();
    }
}