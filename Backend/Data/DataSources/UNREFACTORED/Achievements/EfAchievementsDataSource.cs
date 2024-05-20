using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.UNREFACTORED.Achievements;

public class EfAchievementsDataSource : IAchievementsDataSource
{
    IDbContextFactory<ApplicationContext> _factory;

    public EfAchievementsDataSource(IDbContextFactory<ApplicationContext> context)
    {
        _factory = context;
    }

    public IEnumerable<AchievementDto> SelectByUserId(int userId)
    {
        using var context = _factory.CreateDbContext();
        return context.Achievements.Where(dto => dto.UserId == userId).ToList();
    }

    public AchievementDto? SelectById(int id)
    {
        using var context = _factory.CreateDbContext();
        return context.Achievements.FirstOrDefault(dto => dto.Id == id);
    }

    public int Insert(AchievementDto achievement)
    {
        using var context = _factory.CreateDbContext();
        context.Achievements.Add(achievement);
        context.SaveChanges();
        return achievement.Id;
    }

    public void UpdateById(int id, Action<AchievementDto> updateFunc)
    {
        using var context = _factory.CreateDbContext();
        var updateTarget = SelectById(id);
        if (updateTarget == null) return;
        updateFunc(updateTarget);
        context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        using var context = _factory.CreateDbContext();
        var deleteTarget = SelectById(id);
        if (deleteTarget == null) return;
        context.Achievements.Remove(deleteTarget);
        context.SaveChanges();
    }
}