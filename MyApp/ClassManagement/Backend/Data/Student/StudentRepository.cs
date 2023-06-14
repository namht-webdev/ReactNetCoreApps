
using ClassManagement.Data;
using ClassManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
public class StudentRepository : IStudentRepository
{
    private readonly ClassManagementDbContext _dbContext;

    public StudentRepository(ClassManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Task<bool> CreateAsync(Student Student)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int StudentId)
    {
        throw new NotImplementedException();
    }

    public async Task<Student> ReadStudentAsync(int StudentId)
    {
        var student = await (from s in _dbContext.Student where s.StudentId == StudentId select s).FirstOrDefaultAsync();
        return student;
    }

    public async Task<IEnumerable<Student>> ReadStudentsAsync()
    {
        try
        {
            var students = await (from s in _dbContext.Student select s).ToListAsync();
            return students;
        }
        catch (System.Exception)
        {

        }
        return Enumerable.Empty<Student>();
    }

    public Task<Student> UpdateAsync(int StudentId, Student Student)
    {
        throw new NotImplementedException();
    }
}