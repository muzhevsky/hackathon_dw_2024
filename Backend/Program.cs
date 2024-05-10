using Hackaton_DW_2024.Data;
using Hackaton_DW_2024.Data.DataSources.FileSystem;
using Hackaton_DW_2024.Data.DataSources.News;
using Hackaton_DW_2024.Data.DataSources.Users;
using Hackaton_DW_2024.Data.DataSources.Users.Roles;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

var config = new DatabaseConnectionConfig(new PostgresDatabaseEnvironment());
services.AddSingleton(config);
services.AddSingleton<IUsersDataSource, EfUserDataSource>();
services.AddSingleton<INewsDataSource, EfNewsDataSource>();
services.AddSingleton<IRolesDataSource>(new CachedRoleDataSource(new EfRolesDataSource(config)));
services.AddSingleton<IFileSystem, DefaultFileSystem>();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddCors();
services.AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
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