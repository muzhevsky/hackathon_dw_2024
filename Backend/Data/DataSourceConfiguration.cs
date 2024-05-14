using Hackaton_DW_2024.Data.Config;
using Hackaton_DW_2024.Data.DataSources.Achievements;
using Hackaton_DW_2024.Data.DataSources.Departments;
using Hackaton_DW_2024.Data.DataSources.Events;
using Hackaton_DW_2024.Data.DataSources.Events.Results;
using Hackaton_DW_2024.Data.DataSources.Events.Statuses;
using Hackaton_DW_2024.Data.DataSources.FileSystem;
using Hackaton_DW_2024.Data.DataSources.Groups;
using Hackaton_DW_2024.Data.DataSources.Institutes;
using Hackaton_DW_2024.Data.DataSources.News;
using Hackaton_DW_2024.Data.DataSources.Requests;
using Hackaton_DW_2024.Data.DataSources.Specialities;
using Hackaton_DW_2024.Data.DataSources.Students;
using Hackaton_DW_2024.Data.DataSources.Teachers;
using Hackaton_DW_2024.Data.DataSources.Users;
using Hackaton_DW_2024.Data.DataSources.UsersAndEvents;
using Hackaton_DW_2024.Data.Package;

namespace Hackaton_DW_2024.Data;

public static class DataSourceConfiguration
{
    public static void AddDataSources(this IServiceCollection services)
    {
        // configuration
        services.AddSingleton<DatabaseEnvironment, PostgresDatabaseEnvironment>();
        services.AddSingleton<DatabaseConnectionConfig, DatabaseConnectionConfig>();
        services.AddTransient<ApplicationContext, ApplicationContext>();
        
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
        

        // institute structure
        services.AddSingleton<ISpecialitiesDataSource, EfSpecialitiesDataSource>();
        services.AddSingleton<IGroupsDataSource, EfGroupsDataSource>();
        services.AddSingleton<IDepartmentsDataSource, EfDepartmentsDataSource>();
        services.AddSingleton<IInstituteDataSource, EfInstituteDataSource>();
        
        // users
        services.AddSingleton<IUsersDataSource, EfUserDataSource>();
        services.AddSingleton<IStudentsDataSource, EfStudentsDataSource>();
        services.AddSingleton<ITeacherDataSource, EfTeacherDataSource>();
    }
}