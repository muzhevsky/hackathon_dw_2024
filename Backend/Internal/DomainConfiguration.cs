using Hackaton_DW_2024.Internal.UseCases;

namespace Hackaton_DW_2024.Internal;

public static class DomainConfiguration
{
    public static void AddDomain(this IServiceCollection services)
    {


        
        // services.AddSingleton<UserRepository>();
        // services.AddSingleton<StudentRepository>();
        // services.AddSingleton<AchievementsRepository>();
        // services.AddSingleton<InstituteStructureRepository>();
        // services.AddSingleton<StudentRepository>();
        // services.AddSingleton<DocFileRepository>();
        
        
        services.AddScoped<SignUpStudentUseCase>();
        services.AddScoped<SignUpTeacherUseCase>();
        services.AddScoped<SignInUseCase>();
        // services.AddSingleton<StudentAchievementsUseCase>();
        // services.AddSingleton<StudentRequestUseCase>();
    }
}