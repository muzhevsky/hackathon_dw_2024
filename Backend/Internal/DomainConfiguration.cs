using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;
using Hackaton_DW_2024.Infrastructure.Auth;
using Hackaton_DW_2024.Infrastructure.Hash;
using Hackaton_DW_2024.Internal.Entities;
using Hackaton_DW_2024.Internal.Repositories;
using Hackaton_DW_2024.Internal.UseCases;
using Hackaton_DW_2024.Internal.UseCases.Converters;
using Hackaton_DW_2024.Internal.UseCases.Converters.Achievements;
using Hackaton_DW_2024.Internal.UseCases.Converters.InstituteStructure;
using Hackaton_DW_2024.Internal.UseCases.Converters.Students;
using Hackaton_DW_2024.Internal.UseCases.Converters.User;

namespace Hackaton_DW_2024.Internal;

public static class DomainConfiguration
{
    public static void AddDomain(this IServiceCollection services)
    {
        services.AddSingleton<IConverter<User, UserDto>, UserToDtoConverter>();
        services.AddSingleton<IConverter<UserDto, User>, UserFromDtoConverter>();
        services.AddSingleton<IConverter<Student, StudentDto>, StudentToDtoConverter>();
        services.AddSingleton<IConverter<StudentDto, Student>, StudentFromDtoConverter>();
        services.AddSingleton<IConverter<InstituteDto, Institute>, InstituteFromDtoConverter>();
        services.AddSingleton<IConverter<DepartmentDto, Department>, DepartmentFromDtoConverter>();
        services.AddSingleton<IConverter<GroupDto, Group>, GroupFromDtoConverter>();
        services.AddSingleton<IConverter<AchievementDto, Achievement>, AchievementFromDtoConverter>();
        services.AddSingleton<IConverter<Achievement, AchievementDto>, AchievementToDtoConverter>();

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
    }
}