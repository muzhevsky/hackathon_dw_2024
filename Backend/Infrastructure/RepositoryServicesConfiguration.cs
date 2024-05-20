using Hackaton_DW_2024.Infrastructure.Auth;
using Hackaton_DW_2024.Infrastructure.Hash;
using Hackaton_DW_2024.Infrastructure.Repositories;
using Hackaton_DW_2024.Infrastructure.Repositories.UNREFACTORED;

namespace Hackaton_DW_2024.Infrastructure;

public static class RepositoryServicesConfiguration
{
    /// <summary>
    /// Adds repositories and providers, which grant access to data fetching/modifying methods through api/database
    /// conveniently put together in repository object
    /// </summary>
    public static void AddRepositories(this IServiceCollection services)
    {
        // configuration
        services.AddSingleton<AuthTokenConfiguration, AuthTokenConfiguration>();
        services.AddSingleton<AuthTokenEnvironment, AuthTokenEnvironment>();
        
        services.AddSingleton<GigaChatApiConfiguration>();
        services.AddSingleton<GigaChatEnvironment>();
        
        services.AddSingleton<OcrConfiguration>();
        services.AddSingleton<OcrEnvironment>();
        
        
        // providers
        services.AddScoped<IHashProvider, Sha256HashProvider>();
        services.AddScoped<ISaltProvider, DefaultSaltProvider>();
        services.AddScoped<ITokenProvider, JwtTokenProvider>();
        
        // repositories api
        services.AddScoped<RecognizeTextApiRepository>();
        services.AddScoped<GigaChatRepository>();
        
        // repositories db
        services.AddScoped<UsersRepository>();
        services.AddScoped<StudentsRepository>();
        services.AddScoped<TeachersRepository>();
        services.AddScoped<EventsRepository>();
        services.AddScoped<QuestRepository>();
    }
}