using System.Net.Mime;
using Hackaton_DW_2024.App;
using Hackaton_DW_2024.Data;
using Hackaton_DW_2024.Data.Config;
using Hackaton_DW_2024.Infrastructure.Auth;
using Hackaton_DW_2024.Infrastructure.Logging;
using Hackaton_DW_2024.Internal;
using Hackaton_DW_2024.Internal.UseCases.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.FileProviders;
using ILogger = Hackaton_DW_2024.Infrastructure.Logging.ILogger;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddSingleton<ILogger>(new ConsoleLogger(builder.Environment.IsDevelopment()));
services.AddSingleton<StaticFileConfig>();

services.AddDataSources();
services.AddDomain();
services.AddJwtAuth(new AuthTokenConfiguration(new AuthTokenEnvironment()));

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddCors();
services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
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

app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFileServer(new StaticFileConfig());
app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = MediaTypeNames.Text.Plain;

        await context.Response.WriteAsync("Internal server error.");

        
        var exceptionHandlerPathFeature =
            context.Features.Get<IExceptionHandlerPathFeature>();
        var exception = exceptionHandlerPathFeature?.Error;
        if (exceptionHandlerPathFeature == null) return; 
        
        if (exception is EntityNotFoundException)
            await context.Response.WriteAsync("NoSuchEntity");
        
        else if (exception is AuthException)
        {
            await context.Response.WriteAsync("Unauthorized");
            await context.Response.WriteAsync(exception.ToString());
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        }
        
        else if (exception is DuplicateEntityException)
        {
            await context.Response.WriteAsync("DuplicateEntity");
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        }
    });
});

app.MapControllers();
app.Run();