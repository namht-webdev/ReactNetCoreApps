
using ClassManagement.Data;
using ClassManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
public class StudentRepository : IStudentRepository
{
    private readonly ClassManagementDbContext _dbContext;

    public StudentRepository(ClassManagementDbContext dbContext) => _dbContext = dbContext;
    public async Task<bool> CreateAsync(Student Student)
    {
        var student = await (from s in _dbContext.Student where s.StudentId == Student.StudentId select s).FirstOrDefaultAsync();
        if (student != null) return false;
        Student.PasswordHash = HashPassword(Student.PhoneNumber, Student.PasswordHash);
        await _dbContext.Student.AddAsync(Student);
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

    public async Task<Student> UpdateStudentAsync(string StudentId, Student Student)
    {
        var student = await (from s in _dbContext.Student where s.StudentId == StudentId select s).FirstOrDefaultAsync();
        if (student != null && VerifyPassword(student.PhoneNumber, Student.PasswordHash, Student.PasswordHash))
        {

        }
        if (student != null)
        {
            student.FullName = Student.FullName;
            student.DateOfBirth = Student.DateOfBirth;
            student.DistrictId = Student.DistrictId;
            student.Street = Student.Street;
            student.PhoneNumber = Student.PhoneNumber;
            student.Email = Student.Email;
            student.Avatar = Student.Avatar;
            student.ClassId = Student.ClassId;
            await _dbContext.SaveChangesAsync();
        }
        return student;
    }

    private string HashPassword(string PhoneNumber, string Password)
    {
        var user = new IdentityUser { UserName = PhoneNumber };
        var passwordHasher = new PasswordHasher<IdentityUser>();
        return passwordHasher.HashPassword(user, Password);
    }

    private bool VerifyPassword(string PhoneNumber, string Password, string HashedPassword)
    {
        var user = new IdentityUser { UserName = PhoneNumber };
        var passwordHasher = new PasswordHasher<IdentityUser>();
        var result = passwordHasher.VerifyHashedPassword(user, HashedPassword, Password);
        return result == PasswordVerificationResult.Success;
    }

}