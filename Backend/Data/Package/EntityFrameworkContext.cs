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
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventDto>()
            .HasMany(e => e.Users)
            .WithMany(u => u.Events)
            .UsingEntity<UsersAndEventsDto>(
                builder =>
                {
                    builder
                        .HasOne(ue => ue.User)
                        .WithMany(u => u.UsersAndEvents)
                        .HasForeignKey(ue => ue.UserId);

                    builder
                        .HasOne(ue => ue.Event)
                        .WithMany(e => e.UsersAndEvents)
                        .HasForeignKey(ue => ue.EventId);
                });
        
        modelBuilder.Entity<EventDto>()
            .HasMany(e => e.News)
            .WithMany(n => n.Events)
            .UsingEntity<NewsAndEventsDto>(
                builder =>
                {
                    builder
                        .HasOne(ne => ne.News)
                        .WithMany(n => n.NewsAndEvents)
                        .HasForeignKey(ne => ne.NewsId);

                    builder
                        .HasOne(ne => ne.Event)
                        .WithMany(e => e.NewsAndEvents)
                        .HasForeignKey(ne => ne.EventId);
                });
        
        modelBuilder.Entity<EventDto>() // many to many sample
            .HasMany(e => e.Achievements)
            .WithMany(a => a.Events)
            .UsingEntity<AchievementsAndEventsDto>(
                builder =>
                {
                    builder
                        .HasOne(ae => ae.Achievement)
                        .WithMany(a => a.AchievementsAndEvents)
                        .HasForeignKey(ae => ae.AchievementId);

                    builder
                        .HasOne(ae => ae.Event)
                        .WithMany(e => e.AchievementsAndEvents)
                        .HasForeignKey(ae => ae.EventId);
                });
        
        modelBuilder
            .Entity<StudentDto>()
            .HasOne(s => s.User)
            .WithOne()
            .HasForeignKey<StudentDto>(s => s.UserId);
        
        modelBuilder
            .Entity<StudentDto>()
            .HasOne(s => s.Group)
            .WithOne()
            .HasForeignKey<StudentDto>(s => s.GroupId);
        
        modelBuilder
            .Entity<GroupDto>()
            .HasOne(g => g.Department)
            .WithOne()
            .HasForeignKey<GroupDto>(g => g.DepartmentId);
        
        modelBuilder
            .Entity<DepartmentDto>()
            .HasOne(d => d.Institute)
            .WithOne()
            .HasForeignKey<DepartmentDto>(d => d.InstituteId);
        
        modelBuilder
            .Entity<TeacherDto>()
            .HasOne(t => t.Department)
            .WithOne()
            .HasForeignKey<TeacherDto>(t => t.DepartmentId);
        
        modelBuilder // one to one sample 
            .Entity<EventDto>()
            .HasOne(e => e.Status)
            .WithOne()
            .HasForeignKey<EventDto>(e => e.StatusId);

        modelBuilder // one to many sample
            .Entity<UserDto>() 
            .HasMany(u => u.Achievements)
            .WithOne()
            .HasForeignKey(dto => dto.UserId);
    }
}