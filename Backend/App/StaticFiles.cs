using Hackaton_DW_2024.Data.Config;
using Microsoft.Extensions.FileProviders;

namespace Hackaton_DW_2024.App;

public static class StaticFiles
{
    public static void UseStaticFileServer(this IApplicationBuilder builder, StaticFileConfig config)
    {
        var rootPath = builder.ApplicationServices.GetService<StaticFileConfig>().StaticPath;
        Directory.CreateDirectory(rootPath);
        builder.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(rootPath),
            RequestPath = "/static"
        });
    }
}