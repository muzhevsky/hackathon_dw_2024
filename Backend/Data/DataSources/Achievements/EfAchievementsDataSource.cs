using Hackaton_DW_2024.Data.Config;
using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Data.Dto.Events;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Achievements;

public class EfAchievementsDataSource : EntityFrameworkDataSource, IAchievementsDataSource
{
    DbSet<AchievementDto> _achievements;


    public EfAchievementsDataSource(ApplicationContext context) : base(context)
    {
        _achievements = context.Achievements;
    }
    public IEnumerable<AchievementDto> SelectByUserId(int userId) =>
        _achievements.Where(dto => dto.UserId == userId);

    public AchievementDto? SelectById(int id)
    {
        return _achievements.FirstOrDefault(dto => dto.Id == id);
    }

    public void Insert(AchievementDto achievement)
    {
        _achievements.Add(achievement);
        Context.SaveChanges();
    }

    public void UpdateById(int id, Action<AchievementDto> updateFunc)
    {
        var updateTarget = SelectById(id);
        if (updateTarget == null) return;
        updateFunc(updateTarget);
        Context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        var deleteTarget = SelectById(id);
        if (deleteTarget == null) return;
        _achievements.Remove(deleteTarget);
        Context.SaveChanges();
    }
}