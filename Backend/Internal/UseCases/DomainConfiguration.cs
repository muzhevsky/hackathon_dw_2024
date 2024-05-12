using Hackaton_DW_2024.Api.Requests;
using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Infrastructure.Auth;
using Hackaton_DW_2024.Infrastructure.Hash;
using Hackaton_DW_2024.Internal.Entities;
using Hackaton_DW_2024.Internal.Repositories;
using Hackaton_DW_2024.Internal.UseCases.Converters;

namespace Hackaton_DW_2024.Internal.UseCases;

public static class DomainConfiguration
{
    public static void AddDomain(this IServiceCollection services)
    {
        services.AddSingleton<IConverter<User, UserDto>, UserToDtoConverter>();
        services.AddSingleton<IConverter<UserDto, User>, UserFromDtoConverter>();
        services.AddSingleton<IConverter<Student, StudentDto>, StudentConverter>();

        services.AddSingleton<InstituteStructureRepository, InstituteStructureRepository>();
        services.AddSingleton<StudentRepository, StudentRepository>();
        services.AddSingleton<AuthTokenEnvironment, AuthTokenEnvironment>();
        services.AddSingleton<AuthTokenConfiguration, AuthTokenConfiguration>();
        services.AddSingleton<IHashProvider, Sha256HashProvider>();
        services.AddSingleton<ISaltProvider, DefaultSaltProvider>();
        services.AddSingleton<ITokenProvider, JwtTokenProvider>();
        services.AddSingleton<UserAuthUseCase, UserAuthUseCase>();
    }
}