using Hackaton_DW_2024.Data.Config;
using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Data.Dto.Events;
using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.Package;

public abstract class EntityFrameworkDataSource
{
    protected ApplicationContext Context;
    public EntityFrameworkDataSource(ApplicationContext context)
    {
        Context = context;
    }
}

public class ApplicationContext : DbContext
{
    DatabaseConnectionConfig _config;
    public DbSet<AchievementDto> Achievements { get; set; }
    public DbSet<EventDto> Events { get; set; }
    public DbSet<DepartmentDto> Departments { get; set; }
    public DbSet<GroupDto> Groups { get; set; }
    public DbSet<InstituteDto> Institutes { get; set; }
    public DbSet<UserDto> Users { get; set; }
    public DbSet<StudentDto> Students { get; set; }
    public DbSet<RejectionDto> Rejections { get; set; }
    public DbSet<RequestDto> Requests { get; set; }
    public DbSet<NewsDto> News { get; set; }
    public DbSet<TeacherDto> Teachers { get; set; }
    public DbSet<EventStatusDto> EventStatuses { get; set; }
    public DbSet<UsersAndEventsDto> UsersAndEvents { get; set; }
    
    public ApplicationContext(DatabaseConnectionConfig config)
    {
        _config = config;
        try
        {
            Database.OpenConnection();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
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