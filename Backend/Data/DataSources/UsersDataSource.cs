using System.ComponentModel.DataAnnotations.Schema;
using Hackaton_DW_2024.Data.Dto;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources;

public class UsersDataSource : DbContext
{
    public DbSet<UserDto> Users { get; set; }
    DatabaseConnectionConfig _config;

    public UsersDataSource(DatabaseConnectionConfig config)
    {
        _config = config;
        Database.EnsureCreated();
        foreach (var u in Users)
        {
            Console.WriteLine(u);
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql($"Host={_config.Host};" +
                                 $"Port={_config.Port};" +
                                 $"Database={_config.Database};" +
                                 $"Username={_config.Username};" +
                                 $"Password={_config.Password}");
    }
}

