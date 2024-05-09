using Hackaton_DW_2024.Data.Dto;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Achievements;

public class EFAchievementsDataSource: EntityFrameworkDataSource, IAchievementsDataSource
{
    DbSet<AchievementDto> Achievements;
    public EFAchievementsDataSource(DatabaseConnectionConfig config) : base(config)
    {
    }

    public IEnumerable<AchievementDto> SelectByUserId(int id)
    {
        return Achievements.Where(dto => dto.UserId == id).ToList();
    }

    public AchievementDto? SelectById(int id)
    {
        return Achievements.FirstOrDefault(dto => dto.Id == id);
    }

    public void Insert(AchievementDto achievement)
    {
        Achievements.Add(achievement);
    }

    public void UpdateById(int id, Action<AchievementDto> updateFunc)
    {
        var updateTarget = SelectById(id);
        if (updateTarget == null) throw new Exception("no entity found");
        updateFunc(updateTarget);
        SaveChanges();
    }

    public void DeleteById(int id)
    {
        var deleteTarget = SelectById(id);
        if (deleteTarget == null) throw new Exception("no entity found");
        Achievements.Remove(deleteTarget);
        SaveChanges();
    }
}