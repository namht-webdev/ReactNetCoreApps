using CompanyManagement.Data;
public static class IServiceCollectionExtend
{
    public static IServiceCollection AddRepository(this IServiceCollection service)
    {
        return service.AddScoped<IUserRepository, UserRepository>()
                        .AddScoped<IRoleRepository, RoleRepository>()
                        .AddScoped<ILevelRepository, LevelRepository>()
                        .AddScoped<IDepartmentRepository, DepartmentRepository>()
                        .AddScoped<IRequirementRepository, RequirementRepository>()
                        .AddScoped<IScheduleRepository, ScheduleRepository>();
    }
}