using System.Text;
using Microsoft.EntityFrameworkCore;
using ILogger = Hackaton_DW_2024.Infrastructure.ILogger;

namespace Hackaton_DW_2024.Data.Package;

public abstract class EntityFrameworkDataSource : DbContext
{
    DatabaseConnectionConfig _config;
    ILogger _logger;
    public EntityFrameworkDataSource(DatabaseConnectionConfig config, ILogger logger)
    {
        _config = config;
        _logger = logger;
        try
        {
            Database.OpenConnection();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    protected void RaiseNotFoundError(string tableName, List<KeyValuePair<string, object>> columns)
    {
        var columnsString = new StringBuilder();
        foreach (var keyValuePair in columns)
        {
            columnsString.Append(keyValuePair.Key);
            columnsString.Append(": ");
            columnsString.Append(keyValuePair.Value);
            columnsString.Append("; ");
        }
        _logger.Error(new Exception($"no {tableName} found with {columnsString}"));
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql($"Host={_config.Host};" +
                                 $"Port={_config.Port};" +
                                 $"Database={_config.Database};" +
                                 $"Username={_config.Username};" +
                                 $"Password={_config.Password};",
            builder => builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(20), null));
    }
}