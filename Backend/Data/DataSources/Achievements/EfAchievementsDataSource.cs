using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Achievements;

public class EfAchievementsDataSource : EntityFrameworkDataSource, IAchievementsDataSource
{
    DbSet<AchievementDto> _achievements;

    public EfAchievementsDataSource(DatabaseConnectionConfig config) : base(config)
    {
    }

    public IEnumerable<AchievementDto> SelectByUserId(int userId) =>
        _achievements.Where(dto => dto.UserId == userId).ToList();

    public AchievementDto? SelectById(int id) => _achievements.FirstOrDefault(dto => dto.Id == id);

    public void Insert(AchievementDto achievement)
    {
        _achievements.Add(achievement);
        SaveChanges();
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
        _achievements.Remove(deleteTarget);
        SaveChanges();
    }
}