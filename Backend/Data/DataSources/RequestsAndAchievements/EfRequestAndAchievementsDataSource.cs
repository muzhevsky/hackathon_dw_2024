using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.RequestsAndAchievements;

public class EfRequestAndAchievementsDataSource : EntityFrameworkDataSource, IRequestsAndAchievementsDataSource
{
    DbSet<RequestAndAchievementDto> RequestsAndAchievements;

    public EfRequestAndAchievementsDataSource(DatabaseConnectionConfig config, Infrastructure.ILogger logger) : base(
        config, logger)
    {
    }

    public IEnumerable<RequestAndAchievementDto> SelectByRequestId(int requestId) =>
        RequestsAndAchievements.Where(dto => dto.RequestId == requestId);

    public IEnumerable<RequestAndAchievementDto> SelectByAchievementId(int achievementId) =>
        RequestsAndAchievements.Where(dto => dto.AchievementId == achievementId);

    public void Insert(RequestAndAchievementDto dto)
    {
        RequestsAndAchievements.Add(dto);
        SaveChanges();
    }

    public void Delete(RequestAndAchievementDto dto)
    {
        var deleteTarget = RequestsAndAchievements.FirstOrDefault(record =>
            record.RequestId == dto.RequestId &&
            record.AchievementId == dto.AchievementId
        );
        if (deleteTarget == null)
        {
            RaiseNotFoundError(RequestAndAchievementDto.StructureName,
                new List<KeyValuePair<string, object>>
                {
                    new(nameof(dto.AchievementId), dto.AchievementId),
                    new(nameof(dto.RequestId), dto.RequestId)
                });
        }

        RequestsAndAchievements.Remove(deleteTarget);
        SaveChanges();
    }
}