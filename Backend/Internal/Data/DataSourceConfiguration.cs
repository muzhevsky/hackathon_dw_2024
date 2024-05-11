using Hackaton_DW_2024.Internal.Data.Config;
using Hackaton_DW_2024.Internal.Data.DataSources.Achievements;
using Hackaton_DW_2024.Internal.Data.DataSources.FileSystem;
using Hackaton_DW_2024.Internal.Data.DataSources.News;
using Hackaton_DW_2024.Internal.Data.DataSources.Users;
using Hackaton_DW_2024.Internal.Data.DataSources.Users.Roles;
using ILogger = Hackaton_DW_2024.Infrastructure.Logging.ILogger;

namespace Hackaton_DW_2024.Internal.Data;

public static class DataSourceConfiguration
{
    public static void AddDataSources(this IServiceCollection services)
    {
        services.AddSingleton<DatabaseEnvironment, PostgresDatabaseEnvironment>();
        services.AddSingleton<DatabaseConnectionConfig, DatabaseConnectionConfig>();

        services.AddSingleton<IUsersDataSource, EfUserDataSource>();
        services.AddSingleton<INewsDataSource, EfNewsDataSource>();
        services.AddSingleton<IRolesDataSource>(provider =>
            new CachedRoleDataSource(
                new EfRolesDataSource(
                    provider.GetService<DatabaseConnectionConfig>(),
                    provider.GetService<ILogger>()
                )
            )
        );
        services.AddSingleton<IFileSystem, DefaultFileSystem>();
        services.AddSingleton<IAchievementsDataSource, EfAchievementsDataSource>();
    }
}