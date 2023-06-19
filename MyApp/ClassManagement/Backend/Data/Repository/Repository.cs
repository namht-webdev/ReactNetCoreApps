using ClassManagement.Data;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        return services.AddScoped<IStudentRepository, StudentRepository>()
                        .AddScoped<ITeacherRepository, TeacherRepository>()
                        .AddScoped<IClassRepository, ClassRepository>()
                        .AddScoped<ISubjectRepository, SubjectRepository>()
                        .AddScoped<ISubjectRegisteredRepository, SubjectRegisteredRepository>()
                        .AddScoped<IStudentScoreRepository, StudentScoreRepository>();
    }
}