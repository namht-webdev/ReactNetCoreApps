using ClassManagement.Data;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        return services.AddScoped<IStudentRepository, StudentRepository>();
    }
}