using System.Net.Mime;
using Hackaton_DW_2024.Internal.UseCases.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Hackaton_DW_2024.Api;

class ExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext context,
        Exception exception,
        CancellationToken cancellation)
    {
        Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAaa");
        context.Response.ContentType = MediaTypeNames.Text.Plain;

        if (exception is EntityNotFoundException)
            await context.Response.WriteAsync(exception.Message);

        else if (exception is AuthException)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync(exception.Message);
        }

        else if (exception is DuplicateEntityException)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync(exception.Message);
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync("Internal server error.");
        }

        return false;
    }
}