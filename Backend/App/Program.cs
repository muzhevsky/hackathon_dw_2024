using Hackaton_DW_2024.Data;
using Hackaton_DW_2024.Infrastructure.Auth;
using Hackaton_DW_2024.Infrastructure.Logging;
using Hackaton_DW_2024.Internal;
using Microsoft.Extensions.FileProviders;
using ILogger = Hackaton_DW_2024.Infrastructure.Logging.ILogger;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddSingleton<ILogger>(new ConsoleLogger(builder.Environment.IsDevelopment()));

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
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath)),
    RequestPath = "/static"
});

app.MapControllers();
app.Run();