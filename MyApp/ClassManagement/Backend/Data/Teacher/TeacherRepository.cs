
using ClassManagement.Data;
using ClassManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
public class TeacherRepository : ITeacherRepository
{
    private readonly ClassManagementDbContext _dbContext;

    public TeacherRepository(ClassManagementDbContext dbContext) => _dbContext = dbContext;
    public async Task<bool> CreateTeacherAsync(Teacher Teacher)
    {
        var teacher = await (from s in _dbContext.Teacher where s.TeacherId == Teacher.TeacherId select s).FirstOrDefaultAsync();
        if (teacher != null) return false;
        await _dbContext.Teacher.AddAsync(new Teacher()
        {
            TeacherId = Teacher.TeacherId,
            FullName = Teacher.FullName,
            DateOfBirth = Teacher.DateOfBirth,
            Gender = Teacher.Gender,
            Street = Teacher.Street,
            PhoneNumber = Teacher.PhoneNumber,
            Email = Teacher.Email,
            Avatar = Teacher.Avatar,
            DistrictId = Teacher.DistrictId,
        });
        var response = await _dbContext.SaveChangesAsync();
        return response == 1;
    }

    public async Task<bool> DeleteTeacherAsync(string TeacherId)
    {
        var teacher = await (from s in _dbContext.Teacher where s.TeacherId == TeacherId select s).FirstOrDefaultAsync();
        if (teacher != null)
        {
            _dbContext.Teacher.Remove(teacher);
            var response = await _dbContext.SaveChangesAsync();
            return response == 1;
        };
        return false;
    }

    public async Task<Teacher> ReadTeacherAsync(string TeacherId)
    {
        var teacher = await (from s in _dbContext.Teacher where s.TeacherId == TeacherId select s).FirstOrDefaultAsync();
        return teacher;
    }

    public async Task<IEnumerable<Teacher>> ReadTeachersAsync()
    {
        return await _dbContext.Teacher.ToListAsync();
    }

    public async Task<Teacher> UpdateTeacherAsync(string TeacherId, Teacher Teacher)
    {
        var teacher = await (from s in _dbContext.Teacher where s.TeacherId == TeacherId select s).FirstOrDefaultAsync();
        if (teacher != null)
        {
            teacher.FullName = Teacher.FullName;
            teacher.DateOfBirth = Teacher.DateOfBirth;
            teacher.DistrictId = Teacher.DistrictId;
            teacher.Street = Teacher.Street;
            teacher.PhoneNumber = Teacher.PhoneNumber;
            teacher.Email = Teacher.Email;
            teacher.Avatar = Teacher.Avatar;
            await _dbContext.SaveChangesAsync();
        }
        return teacher;
    }
}