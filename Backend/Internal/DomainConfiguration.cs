using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Infrastructure.Auth;
using Hackaton_DW_2024.Infrastructure.Hash;
using Hackaton_DW_2024.Internal.Converters;
using Hackaton_DW_2024.Internal.Converters.Students;
using Hackaton_DW_2024.Internal.Converters.User;
using Hackaton_DW_2024.Internal.Entities.Users;
using Hackaton_DW_2024.Internal.Repositories;
using Hackaton_DW_2024.Internal.Repositories.Api;
using Hackaton_DW_2024.Internal.Repositories.Database;
using Hackaton_DW_2024.Internal.UseCases;

namespace Hackaton_DW_2024.Internal;

public static class DomainConfiguration
{
    public static void AddDomain(this IServiceCollection services)
    {
        services.AddSingleton<IConverter<User, UserDto>, UserToDtoConverter>();
        services.AddSingleton<IConverter<UserDto, User>, UserFromDtoConverter>();
        services.AddSingleton<IConverter<StudentDto, Student>, StudentFromDtoConverter>();
        services.AddSingleton<IConverter<Student, StudentDto>, StudentToDtoConverter>();

        services.AddSingleton<GigaChatEnvironment>();
        services.AddSingleton<GigaChatApiConfiguration>();
        services.AddSingleton<OcrEnvironment>();
        services.AddSingleton<OcrConfiguration>();
        
        services.AddSingleton<UserRepository, UserRepository>();
        services.AddSingleton<StudentRepository, StudentRepository>();
        services.AddSingleton<AchievementsRepository, AchievementsRepository>();
        services.AddSingleton<InstituteStructureRepository, InstituteStructureRepository>();
        services.AddSingleton<StudentRepository, StudentRepository>();
        services.AddSingleton<AuthTokenEnvironment, AuthTokenEnvironment>();
        services.AddSingleton<AuthTokenConfiguration, AuthTokenConfiguration>();
        services.AddSingleton<IHashProvider, Sha256HashProvider>();
        services.AddSingleton<ISaltProvider, DefaultSaltProvider>();
        services.AddSingleton<ITokenProvider, JwtTokenProvider>();
        services.AddSingleton<AuthUseCase, AuthUseCase>();
        services.AddSingleton<StudentProfileUseCase, StudentProfileUseCase>();
        services.AddSingleton<RecognizeTextApiRepository>();
        services.AddSingleton<GigaChatRepository>();
    }
}