using Hackaton_DW_2024.Api.Requests;
using Hackaton_DW_2024.Infrastructure.Auth;
using Hackaton_DW_2024.Infrastructure.Hash;
using Hackaton_DW_2024.Internal.Data.Dto.Users;
using Hackaton_DW_2024.Internal.Repositories;
using Hackaton_DW_2024.Internal.UseCases.Converters;

namespace Hackaton_DW_2024.Internal.UseCases;

public static class DomainConfiguration
{
    public static void AddDomain(this IServiceCollection services)
    {
        services.AddSingleton<IConverter<SignUpRequest, UserDto>, SignUpRequestToUserDto>();
        services.AddSingleton<IConverter<Role, int>, RoleToIntConverter>();
        services.AddSingleton<UserRepository, UserRepository>();
        services.AddSingleton<AuthTokenEnvironment, AuthTokenEnvironment>();
        services.AddSingleton<AuthTokenConfiguration, AuthTokenConfiguration>();
        services.AddSingleton<IHashProvider, Sha256HashProvider>();
        services.AddSingleton<ITokenProvider, JwtTokenProvider>();
        services.AddSingleton<AuthUseCase, AuthUseCase>();
    }
}