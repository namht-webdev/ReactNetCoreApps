using Microsoft.EntityFrameworkCore;
using CompanyManagement.Models;
public class CompanyManagementDbContext : DbContext
{
    public CompanyManagementDbContext(DbContextOptions<CompanyManagementDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //     modelBuilder.Entity<Department>(department =>
        //     {
        //         department.HasOne(department => department.user).WithOne(user => user.department).HasForeignKey<Department>(department => department.user_id);
        //     });
        //     modelBuilder.Entity<User>(user =>
        //     {
        //         user.HasOne(user => user.department).WithOne(department => department.user).HasForeignKey<User>(user => user.department_id);
        //     });

        //     modelBuilder.Entity<Address>(addresse =>
        //     {
        //         addresse.HasOne(addresse => addresse.ward).WithOne(ward => ward.address).HasForeignKey<Address>(addresse => addresse.ward_id);
        //     });
        //     modelBuilder.Entity<Ward>(ward =>
        //     {
        //         ward.HasOne(ward => ward.address).WithOne(addresse => addresse.ward).HasForeignKey<Ward>(ward => ward.address_id);
        //     });

        //     modelBuilder.Entity<User>(user =>
        //     {
        //         user.HasOne(user => user.level).WithOne(level => level.user).HasForeignKey<User>(user => user.level_id);
        //     });
        //     modelBuilder.Entity<Level>(level =>
        //     {
        //         level.HasOne(level => level.user).WithOne(user => user.level).HasForeignKey<Level>(level => level.user_id);
        //     });

        //     modelBuilder.Entity<User>(user =>
        //     {
        //         user.HasOne(user => user.role).WithOne(role => role.user).HasForeignKey<User>(user => user.role_id);
        //     });
        //     modelBuilder.Entity<Role>(role =>
        //     {
        //         role.HasOne(role => role.user).WithOne(user => user.role).HasForeignKey<Role>(role => role.user_id);
        //     });
        //     // one - to - many

        //     modelBuilder.Entity<Department>(announcement =>
        //     {
        //         announcement.HasMany(department => department.announcements).WithOne(announcement => announcement.department);
        //     });

        //     modelBuilder.Entity<User>(user =>
        //     {
        //         user.HasMany(user => user.announcements).WithOne(announcement => announcement.user);
        //     });

        //     modelBuilder.Entity<Province>(user =>
        //     {
        //         user.HasMany(province => province.districts).WithOne(district => district.province);
        //     });

        //     modelBuilder.Entity<User>(user =>
        //    {
        //        user.HasMany(user => user.schedules).WithOne(schedule => schedule.user);
        //    });

        // modelBuilder.Entity<Requirement>(requirement =>
        // {
        //     requirement.HasOne(requirement => requirement.from_user).WithMany().HasForeignKey(requirement => requirement.from_user).OnDelete(DeleteBehavior.NoAction);
        //     requirement.HasOne(requirement => requirement.to_user).WithMany().HasForeignKey(requirement => requirement.to_user).OnDelete(DeleteBehavior.NoAction);
        // });

    }
    public DbSet<User> user { get; set; }
    public DbSet<FingerPrinting> fingerprinting { get; set; }
    public DbSet<Level> level { get; set; }
    public DbSet<Role> role { get; set; }
    public DbSet<Ward> ward { get; set; }
    public DbSet<District> district { get; set; }
    public DbSet<Province> province { get; set; }
    public DbSet<Address> addresse { get; set; }
    public DbSet<Department> department { get; set; }
    public DbSet<Announcement> announcement { get; set; }
    public DbSet<Schedule> schedule { get; set; }
    public DbSet<Requirement> requirement { get; set; }
}