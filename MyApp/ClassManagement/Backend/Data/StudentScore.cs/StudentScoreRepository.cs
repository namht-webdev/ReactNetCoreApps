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

    public async Task<IEnumerable<ScoreOneSubjectViewModel>> ReadClassStudentScoreAsync(string ClassId)
    {
        // List<StudentScoreViewModel> studentScores = new List<StudentScoreViewModel>();
        // var students = await _dbContext.Student.Where(s => s.ClassId == ClassId).ToListAsync();
        // //var studentScore = _dbContext.StudentScore.Select(ss => studentsIds.Contains(ss.StudentId));
        // if (students == null) return Enumerable.Empty<StudentScoreViewModel>();
        // students.ForEach(s =>
        // {
        //     _dbContext.Entry<Student>(s).Reference(s => s.StudentScore).Load();
        //     studentScores.Add(new StudentScoreViewModel() { 
        //         StudentId = s.StudentId            });
        // });

        return Enumerable.Empty<ScoreOneSubjectViewModel>();
    }

    public async Task<ScoreOneSubjectViewModel> ReadScoreOneSubjectAsync(string SubjectId, string StudentId)
    {
        var studentScore = await _dbContext.StudentScore.FirstOrDefaultAsync(ss => ss.SubjectId == SubjectId && ss.StudentId == StudentId);
        if (studentScore == null) return null;
        var studentName = await _dbContext.Student.Where(s => s.StudentId == studentScore.StudentId).Select(s => s.FullName).FirstOrDefaultAsync();
        _dbContext.Entry(studentScore).Reference(ss => ss.Subject).Load();
        return new ScoreOneSubjectViewModel
        {
            StudentId = studentScore.StudentId,
            StudentName = studentName!,
            SubjectScore = new SubjectScore
            {
                SubjectName = studentScore.Subject!.SubjectName,
                AvgScore = studentScore.Score
            }
        };
    }

    public async Task<ScoreAllSubjectViewModel> ReadScoreAllSubjectAsync(string StudentId)
    {
        var studentScore = await _dbContext.StudentScore.Where(ss => ss.StudentId == StudentId).ToListAsync();
        if (studentScore == null) return null;
        var studentName = await _dbContext.Student.Where(s => s.StudentId == studentScore.First().StudentId).Select(s => s.FullName).FirstOrDefaultAsync();
        studentScore.ForEach(ss =>
        {
            _dbContext.Entry(ss).Reference(ss => ss.Subject).Load();
        });
        var scoreAllSubject = new ScoreAllSubjectViewModel()
        {
            StudentId = StudentId,
            StudentName = studentName!,
            SubjectScores = new List<SubjectScore>(),
        };
        studentScore.ForEach(ss =>
        {
            scoreAllSubject.SubjectScores.Add(new SubjectScore
            {
                SubjectName = ss.Subject!.SubjectName,
                AvgScore = ss.Score
            });
        });
        return scoreAllSubject;
    }

    public async Task<StudentScore> UpdateStudentScoreAsync(string SubjectId, string StudentId, double Score)
    {
        var student = await _dbContext.StudentScore.FirstOrDefaultAsync(s => s.StudentId == StudentId && s.SubjectId == SubjectId);
        if (student == null) return null;
        student.Score = Score;
        await _dbContext.SaveChangesAsync();
        int result = await _dbContext.SaveChangesAsync();
        return student;
    }
}