using Hackaton_DW_2024.Data.Config;
using Hackaton_DW_2024.Data.Converters;
using Hackaton_DW_2024.Data.Converters.Students;
using Hackaton_DW_2024.Data.Converters.Teachers;
using Hackaton_DW_2024.Data.Converters.Users;
using Hackaton_DW_2024.Data.DataSources;
using Hackaton_DW_2024.Data.DataSources.StudentsDS;
using Hackaton_DW_2024.Data.DataSources.TeachersDS;
using Hackaton_DW_2024.Data.DataSources.UNREFACTORED.Achievements;
using Hackaton_DW_2024.Data.DataSources.UNREFACTORED.Departments;
using Hackaton_DW_2024.Data.DataSources.UNREFACTORED.Events;
using Hackaton_DW_2024.Data.DataSources.UNREFACTORED.Events.Results;
using Hackaton_DW_2024.Data.DataSources.UNREFACTORED.Events.Statuses;
using Hackaton_DW_2024.Data.DataSources.UNREFACTORED.FileSystem;
using Hackaton_DW_2024.Data.DataSources.UNREFACTORED.Groups;
using Hackaton_DW_2024.Data.DataSources.UNREFACTORED.Institutes;
using Hackaton_DW_2024.Data.DataSources.UNREFACTORED.News;
using Hackaton_DW_2024.Data.DataSources.UNREFACTORED.Quests;
using Hackaton_DW_2024.Data.DataSources.UNREFACTORED.Requests;
using Hackaton_DW_2024.Data.DataSources.UNREFACTORED.Specialities;
using Hackaton_DW_2024.Data.DataSources.UNREFACTORED.UsersAndEvents;
using Hackaton_DW_2024.Data.DataSources.UsersDS;
using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Data.Package;
using Hackaton_DW_2024.Infrastructure.Repositories;
using Hackaton_DW_2024.Internal.Entities;

namespace Hackaton_DW_2024.Infrastructure;

public static class DataSourceServiceConfiguration
{
    /// <summary>
    /// Adds database configuration, converters and command executors (ICommandExecutor), which are used by repositories
    /// </summary>
    public static void AddDataSources(this IServiceCollection services)
    {
        // configuration
        services.AddSingleton<DatabaseEnvironment, PostgresDatabaseEnvironment>();
        services.AddSingleton<DatabaseConnectionConfig, DatabaseConnectionConfig>();
        services.AddDbContextFactory<ApplicationContext>();
        
        // converters
        services.AddScoped<IConverter<User, EfUserDto>, UserToEfDtoConverter>();
        services.AddScoped<IConverter<EfUserDto, User>, UserFromEfDtoConverter>();
        
        services.AddScoped<IConverter<Student, EfStudentDto>, StudentToEfDtoConverter>();
        services.AddScoped<IConverter<EfStudentDto, Student>, StudentFromEfDtoConverter>();

        services.AddScoped<IConverter<Teacher, EfTeacherDto>, TeacherToEfDtoConverter>();
        services.AddScoped<IConverter<EfTeacherDto, Teacher>, TeacherFromEfDtoConverter>();
        
        
        // user
        services.AddScoped<ICommandExecutor<UserByLoginQuery, User?>, EfFindUserByLoginQueryExecutor>();
        services.AddScoped<ICommandExecutor<UserByIdQuery, User?>, EfFindUserByIdQueryExecutor>();
        
        
        // student
        services.AddScoped<ICommandExecutor<Student, int>, EfCreateStudentExecutor>();
        services.AddScoped<ICommandExecutor<CreateStudentCommand, int>, EfCreateStudentCommandExecutor>();
        services.AddScoped<ICommandExecutor<StudentByIdQuery, Student?>, EfFindStudentByIdQueryExecutor>();
        services.AddScoped<ICommandExecutor<StudentByStudentIdQuery, Student?>, EfFindStudentByStudentIdQueryExecutor>();
        services.AddScoped<ICommandExecutor<StudentByUserIdQuery, Student?>, EfFindStudentByUserIdQueryExecutor>();
        
        
        // teacher
        services.AddScoped<ICommandExecutor<Teacher, int>, EfCreateTeacherExecutor>();
        services.AddScoped<ICommandExecutor<CreateTeacherWithUserCommand, int>, EfCreateTeacherWithUserCommandExecutor>();
        services.AddScoped<ICommandExecutor<TeacherByIdQuery, Teacher?>, EfFindTeacherByIdQueryExecutor>();
        services.AddScoped<ICommandExecutor<TeacherByUserIdQuery, Teacher?>, EfFindTeacherByUserIdQueryExecutor>();
        services.AddScoped<ICommandExecutor<TeacherByDepartmentIdQuery, List<Teacher>>, EfFindTeachersByDepartmentIdQueryExecutor>();
        
        
        
        
        
        //news and events
        services.AddSingleton<IEventsDataSource, EfEventsDataSource>();
        services.AddSingleton<INewsDataSource, EfNewsDataSource>();
        services.AddSingleton<IAchievementsDataSource, EfAchievementsDataSource>();
        services.AddSingleton<IFileSystem, DefaultFileSystem>();
        services.AddSingleton<IEventStatusesDataSource, EfEventStatusesDataSource>();
        services.AddSingleton<IEventResultsDataSource, EfEventResultDataSource>();
        services.AddSingleton<ICustomAchievementDataSource, EfCustomAchievementDataSource>();
        services.AddSingleton<IUsersAndEventsDataSource, EfUsersAndEventsDataSource>();
        services.AddSingleton<IRequestDataSource, EfRequestDataSource>();
        services.AddSingleton<IQuestsDataSource, EfQuestsDataSource>();
        

        // institute structure
        services.AddSingleton<ISpecialitiesDataSource, EfSpecialitiesDataSource>();
        services.AddSingleton<IGroupsDataSource, EfGroupsDataSource>();
        services.AddSingleton<IDepartmentsDataSource, EfDepartmentsDataSource>();
        services.AddSingleton<IInstituteDataSource, EfInstituteDataSource>();
    }
}