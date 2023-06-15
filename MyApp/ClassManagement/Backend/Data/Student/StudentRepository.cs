
using ClassManagement.Data;
using ClassManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
public class StudentRepository : IStudentRepository
{
    private readonly ClassManagementDbContext _dbContext;

    public StudentRepository(ClassManagementDbContext dbContext) => _dbContext = dbContext;
    public async Task<bool> CreateAsync(Student Student)
    {
        var student = await (from s in _dbContext.Student where s.StudentId == Student.StudentId select s).FirstOrDefaultAsync();
        if (student != null) return false;
        await _dbContext.Student.AddAsync(new Student()
        {
            StudentId = Student.StudentId,
            FullName = Student.FullName,
            DateOfBirth = Student.DateOfBirth,
            Gender = Student.Gender,
            Street = Student.Street,
            PhoneNumber = Student.PhoneNumber,
            Email = Student.Email,
            Avatar = Student.Avatar,
            ClassId = Student.ClassId,
            DistrictId = Student.DistrictId,
            Absent = Student.Absent,
            StudentScore = Student.StudentScore
        });
        var response = await _dbContext.SaveChangesAsync();
        return response == 1;
    }

    public async Task<bool> DeleteTeacherAsync(string StudentId)
    {
        var student = await (from s in _dbContext.Student where s.StudentId == StudentId select s).FirstOrDefaultAsync();
        if (student != null)
        {
            _dbContext.Student.Remove(student);
            var response = await _dbContext.SaveChangesAsync();
            return response == 1;
        };
        return false;
    }

    public async Task<Student> ReadStudentAsync(string StudentId)
    {
        var student = await (from s in _dbContext.Student where s.StudentId == StudentId select s).FirstOrDefaultAsync();
        return student;
    }

    public async Task<IEnumerable<Student>> ReadStudentsAsync()
    {
        return await _dbContext.Student.ToListAsync();
    }

    public async Task<Student> UpdateTeacherAsync(string StudentId, Student Student)
    {
        var student = await (from s in _dbContext.Student where s.StudentId == StudentId select s).FirstOrDefaultAsync();
        if (student != null)
        {
            student.FullName = Student.FullName;
            student.DateOfBirth = Student.DateOfBirth;
            student.DistrictId = Student.DistrictId;
            student.Street = Student.Street;
            student.PhoneNumber = Student.PhoneNumber;
            student.Email = Student.Email;
            student.Avatar = Student.Avatar;
            await _dbContext.SaveChangesAsync();
        }
        return student;
    }
}