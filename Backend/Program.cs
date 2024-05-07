using Hackaton_DW_2024.Controllers;
using Hackaton_DW_2024.Data;
using Hackaton_DW_2024.Data.DataSources;
using Microsoft.AspNetCore.Http.HttpResults;
using Npgsql;
using Npgsql.Internal;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddSingleton(new DatabaseConnectionConfig(new PostgresDatabaseEnvironment()));
services.AddSingleton<UsersDataSource>();
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