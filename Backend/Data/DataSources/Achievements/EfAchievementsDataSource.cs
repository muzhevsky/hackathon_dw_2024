using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Achievements;

public class EfAchievementsDataSource : EntityFrameworkDataSource, IAchievementsDataSource
{
    DbSet<AchievementDto> _achievements { get; set; }

    public EfAchievementsDataSource(DatabaseConnectionConfig config, Infrastructure.ILogger logger) : base(config,
        logger)
    {
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
        SaveChanges();
    }

    public void UpdateById(int id, Action<AchievementDto> updateFunc)
    {
        var updateTarget = SelectById(id);
        if (updateTarget == null)
        {
            RaiseNotFoundError(AchievementDto.StructureName,
                new List<KeyValuePair<string, object>>
                {
                    new(nameof(AchievementDto.Id), id)
                });
            return;
        }

        updateFunc(updateTarget);
        SaveChanges();
    }

    public void DeleteById(int id)
    {
        var deleteTarget = SelectById(id);
        if (deleteTarget == null)
        {
            RaiseNotFoundError(AchievementDto.StructureName,
                new List<KeyValuePair<string, object>>
                {
                    new(nameof(AchievementDto.Id), id)
                });
            return;
        }

        _achievements.Remove(deleteTarget);
        SaveChanges();
    }
}