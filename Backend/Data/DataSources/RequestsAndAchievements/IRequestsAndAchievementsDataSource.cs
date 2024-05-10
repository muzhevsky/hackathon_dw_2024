using Hackaton_DW_2024.Data.Dto.Achievements;

namespace Hackaton_DW_2024.Data.DataSources.RequestsAndAchievements;

public interface IRequestsAndAchievementsDataSource
{
    IEnumerable<RequestsAndAchievementDto> SelectByRequestId(int requestId);
    IEnumerable<RequestsAndAchievementDto> SelectByAchievementId(int achievementId);
    void Insert(RequestsAndAchievementDto dto);
    void Delete(RequestsAndAchievementDto dto);
}