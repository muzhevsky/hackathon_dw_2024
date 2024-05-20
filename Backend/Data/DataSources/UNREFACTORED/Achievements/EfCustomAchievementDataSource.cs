using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.UNREFACTORED.Achievements;

public class EfCustomAchievementDataSource:  ICustomAchievementDataSource
{
    IDbContextFactory<ApplicationContext> _factory;
    public EfCustomAchievementDataSource(IDbContextFactory<ApplicationContext>  context)
    {
        _factory = context;
    }

    public CustomAchievementDto? SelectById(int id)
    {
        using var context = _factory.CreateDbContext();
        return context.CustomAchievements.FirstOrDefault(dto => dto.Id == id);
    }

    public CustomAchievementDto? SelectByAchievementId(int id)
    {
        using var context = _factory.CreateDbContext();
        return context.CustomAchievements.FirstOrDefault(dto => dto.AchievementId == id);
    }

    public void Insert(CustomAchievementDto dto)
    {
        using var context = _factory.CreateDbContext();
        context.CustomAchievements.Add(dto);
        context.SaveChanges();
    }

    public void RemoveById(int id)
    {
        using var context = _factory.CreateDbContext();
        var deleteTarget = SelectById(id);
        if (deleteTarget == null) return;
        context.CustomAchievements.Remove(deleteTarget);
        context.SaveChanges();
    }
}