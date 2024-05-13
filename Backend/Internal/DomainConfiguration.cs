using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;
using Hackaton_DW_2024.Infrastructure.Auth;
using Hackaton_DW_2024.Infrastructure.Hash;
using Hackaton_DW_2024.Infrastructure.Repositories.Api;
using Hackaton_DW_2024.Infrastructure.Repositories.Database;
using Hackaton_DW_2024.Internal.Converters;
using Hackaton_DW_2024.Internal.Converters.InstituteStructure;
using Hackaton_DW_2024.Internal.Converters.Students;
using Hackaton_DW_2024.Internal.Converters.User;
using Hackaton_DW_2024.Internal.Entities;
using Hackaton_DW_2024.Internal.Entities.Users;
using Hackaton_DW_2024.Internal.UseCases;

namespace Hackaton_DW_2024.Internal;

public static class DomainConfiguration
{
    public static void AddDomain(this IServiceCollection services)
    {
        services.AddSingleton<IConverter<User, UserDto>, UserDtoConverter>();
        services.AddSingleton<IConverter<Student, StudentDto>, StudentDtoConverter>();
        services.AddSingleton<IConverter<Group, GroupDto>, GroupDtoConverter>();
        services.AddSingleton<IConverter<Institute, InstituteDto>, InstituteDtoConverter>();
        services.AddSingleton<IConverter<Department, DepartmentDto>, DepartmentDtoConverter>();
        services.AddSingleton<IConverter<Speciality, SpecialityDto>, SpecialityDtoConverter>();

        services.AddSingleton<GigaChatEnvironment>();
        services.AddSingleton<GigaChatApiConfiguration>();
        services.AddSingleton<OcrEnvironment>();
        services.AddSingleton<OcrConfiguration>();
        services.AddSingleton<AuthTokenEnvironment, AuthTokenEnvironment>();
        services.AddSingleton<AuthTokenConfiguration, AuthTokenConfiguration>();
        
        services.AddSingleton<IHashProvider, Sha256HashProvider>();
        services.AddSingleton<ISaltProvider, DefaultSaltProvider>();
        services.AddSingleton<ITokenProvider, JwtTokenProvider>();
        
        services.AddSingleton<UserRepository>();
        services.AddSingleton<StudentRepository>();
        services.AddSingleton<AchievementsRepository>();
        services.AddSingleton<InstituteStructureRepository>();
        services.AddSingleton<StudentRepository>();
        services.AddSingleton<RecognizeTextApiRepository>();
        services.AddSingleton<GigaChatRepository>();
        services.AddSingleton<DocFileRepository>();
        
        
        services.AddSingleton<AuthUseCase>();
        services.AddSingleton<StudentAchievementsUseCase>();
        services.AddSingleton<StudentRequestUseCase>();
    }
}