using Microsoft.EntityFrameworkCore;
using ClassManagement.Models;
namespace ClassManagement.Data;
public class ClassManagementDbContext : DbContext
{
    public ClassManagementDbContext(DbContextOptions<ClassManagementDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Absent>(absent =>
        {
            absent.HasOne(absent => absent.Student).WithMany(student => student.Absent);
        });
        modelBuilder.Entity<Address>(address =>
        {
            address.HasOne(address => address.District).WithMany(district => district.Address);
        });
        modelBuilder.Entity<Class>(classes =>
        {
            classes.HasMany(classs => classs.SubjectRegisted).WithOne(subjectRegisted => subjectRegisted.Class);
            classes.HasMany(classs => classs.Student).WithOne(student => student.Class);
        });

        modelBuilder.Entity<Province>(province =>
        {
            province.HasMany(province => province.District).WithOne(district => district.Province);
        });

        modelBuilder.Entity<Student>(student =>
        {
            student.HasMany(student => student.Absent).WithOne(student => student.Student);
            student.HasMany(student => student.StudentScore).WithOne(score => score.Student);
        });

        modelBuilder.Entity<Subject>(subject =>
        {
            subject.HasMany(subject => subject.SubjectRegisted).WithOne(subjectRegisted => subjectRegisted.Subject);
        });

    }
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