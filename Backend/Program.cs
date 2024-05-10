using Hackaton_DW_2024.Data;
using Hackaton_DW_2024.Data.DataSources.Achievements;
using Hackaton_DW_2024.Data.DataSources.FileSystem;
using Hackaton_DW_2024.Data.DataSources.News;
using Hackaton_DW_2024.Data.DataSources.Users;
using Hackaton_DW_2024.Data.DataSources.Users.Roles;
using Hackaton_DW_2024.Infrastructure;
using ILogger = Hackaton_DW_2024.Infrastructure.ILogger;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

var config = new DatabaseConnectionConfig(new PostgresDatabaseEnvironment());
var logger = new ConsoleLogger(builder.Environment.IsDevelopment());

services.AddSingleton<ILogger>(logger);
services.AddSingleton(config);
services.AddSingleton<IUsersDataSource, EfUserDataSource>();
services.AddSingleton<INewsDataSource, EfNewsDataSource>();
services.AddSingleton<IRolesDataSource>(new CachedRoleDataSource(new EfRolesDataSource(config, logger)));
services.AddSingleton<IFileSystem, DefaultFileSystem>();
services.AddSingleton<IAchievementsDataSource, EfAchievementsDataSource>();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddCors();
services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment()){
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHttpsRedirection();
app.UseCors(policy =>
{
    policy.AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(_ => true)
        .AllowCredentials();
});

app.MapControllers();
app.Run();