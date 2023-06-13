using Microsoft.EntityFrameworkCore;
using ClassManagement.Models;
namespace ClassManagement.Data;
public class ClassManagementDbContext : DbContext
{
    public ClassManagementDbContext(DbContextOptions<ClassManagementDbContext> options) : base(options) { }
    public DbSet<Class> Class { get; set; }
    public DbSet<Subject> Subject { get; set; }
    public DbSet<SubjectRegisted> SubjectRegisted { get; set; }
    public DbSet<Student> Student { get; set; }
    public DbSet<Teacher> Teacher { get; set; }
    public DbSet<Absent> Absent { get; set; }
    public DbSet<StudentScore> StudentScore { get; set; }
    public DbSet<Province> Province { get; }
    public DbSet<District> District { get; }
    public DbSet<Address> Address { get; set; }
}