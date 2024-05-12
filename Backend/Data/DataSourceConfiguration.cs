using Hackaton_DW_2024.Data.Config;
using Hackaton_DW_2024.Data.DataSources.Achievements;
using Hackaton_DW_2024.Data.DataSources.Departments;
using Hackaton_DW_2024.Data.DataSources.Events;
using Hackaton_DW_2024.Data.DataSources.FileSystem;
using Hackaton_DW_2024.Data.DataSources.Groups;
using Hackaton_DW_2024.Data.DataSources.Institutes;
using Hackaton_DW_2024.Data.DataSources.News;
using Hackaton_DW_2024.Data.DataSources.Students;
using Hackaton_DW_2024.Data.DataSources.Users;
using Hackaton_DW_2024.Data.Package;

namespace Hackaton_DW_2024.Data;

public static class DataSourceConfiguration
{
    public static void AddDataSources(this IServiceCollection services)
    {
        services.AddSingleton<DatabaseEnvironment, PostgresDatabaseEnvironment>();
        services.AddSingleton<DatabaseConnectionConfig, DatabaseConnectionConfig>();


        services.AddSingleton<ApplicationContext, ApplicationContext>();
        services.AddSingleton<IEventsDataSource, EfEventsDataSource>();
        services.AddSingleton<IGroupsDataSource, EfGroupsDataSource>();
        services.AddSingleton<IDepartmentsDataSource, EfDepartmentsDataSource>();
        services.AddSingleton<IInstituteDataSource, EfInstituteDataSource>();
        services.AddSingleton<IUsersDataSource, EfUserDataSource>();
        services.AddSingleton<IStudentsDataSource, EfStudentsDataSource>();
        services.AddSingleton<INewsDataSource, EfNewsDataSource>();
        services.AddSingleton<IFileSystem, DefaultFileSystem>();
        services.AddSingleton<IAchievementsDataSource, EfAchievementsDataSource>();
    }
}