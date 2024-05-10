using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.RequestsAndAchievements;

public class EfRequestAndAchievementsDataSource: EntityFrameworkDataSource, IRequestsAndAchievementsDataSource
{
    DbSet<RequestsAndAchievementDto> RequestsAndAchievements;
    public EfRequestAndAchievementsDataSource(DatabaseConnectionConfig config) : base(config)
    {
    }

    public IEnumerable<RequestsAndAchievementDto> SelectByRequestId(int requestId) =>
        RequestsAndAchievements.Where(dto => dto.RequestId == requestId);

    public IEnumerable<RequestsAndAchievementDto> SelectByAchievementId(int achievementId) =>
        RequestsAndAchievements.Where(dto => dto.AchievementId == achievementId);

    public void Insert(RequestsAndAchievementDto dto)
    {
        RequestsAndAchievements.Add(dto);
        SaveChanges();
    }

    public void Delete(RequestsAndAchievementDto dto)
    {
        var deleteTarget = RequestsAndAchievements.FirstOrDefault(record =>
            record.RequestId == dto.RequestId &&
            record.AchievementId == dto.AchievementId
        );
        if (deleteTarget == null) throw new Exception("no entity found");
        RequestsAndAchievements.Remove(deleteTarget);
        SaveChanges();
    }
}