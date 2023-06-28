using CompanyManagement.Data;
public static class IServiceCollectionExtend
{
    public static IServiceCollection AddRepository(this IServiceCollection service)
    {
        return service.AddScoped<IUserRepository, UserRepository>();
    }
}