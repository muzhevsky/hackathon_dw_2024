using Hackaton_DW_2024.Internal.Data.Dto.Achievements;

namespace Hackaton_DW_2024.Internal.Data.DataSources.RequestsAndAchievements;

public interface IRequestsAndAchievementsDataSource
{
    IEnumerable<RequestAndAchievementDto> SelectByRequestId(int requestId);
    IEnumerable<RequestAndAchievementDto> SelectByAchievementId(int achievementId);
    void Insert(RequestAndAchievementDto dto);
    void Delete(RequestAndAchievementDto dto);
}