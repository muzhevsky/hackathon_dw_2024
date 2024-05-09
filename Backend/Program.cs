using System.Net.Mime;
using Hackaton_DW_2024.Controllers;
using Hackaton_DW_2024.Data;
using Hackaton_DW_2024.Data.DataSources;
using Hackaton_DW_2024.Data.DataSources.FileSystem;
using Hackaton_DW_2024.Data.DataSources.News;
using Hackaton_DW_2024.Data.DataSources.Users;
using Hackaton_DW_2024.Data.DataSources.Users.Roles;
using Hackaton_DW_2024.Data.Dto;
using Microsoft.AspNetCore.Http.HttpResults;
using Npgsql;
using Npgsql.Internal;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

var config = new DatabaseConnectionConfig(new PostgresDatabaseEnvironment());
services.AddSingleton(config);
services.AddSingleton<IUsersDataSource, EFUserDataSource>();
services.AddSingleton<INewsDataSource, EFNewsDataSource>();
services.AddSingleton<IRolesDataSource>(new CachedRoleDataSource(new EFRolesDataSource(config)));
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