using Hackaton_DW_2024.Data.DataSources.Achievements;
using Hackaton_DW_2024.Data.DataSources.AchievementsAndEvents;
using Hackaton_DW_2024.Data.DataSources.RequestsAndAchievements;
using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Data.Dto.Users;

namespace Hackaton_DW_2024.Data.Repositories;

public class AchievementsRepository
{
    IAchievementsDataSource _achievementsDataSource;
    IAchievementsAndEventsDataSource _achievementsAndEventsDataSource;
    IRequestsAndAchievementsDataSource _requestsAndAchievementsDataSource;

    List<AchievementDto> GetByUser(UserDto user) => _achievementsDataSource.SelectByUserId(user.Id).ToList();

    List<AchievementDto> GetByRequest(RequestDto request)
    {
        var recordIds = _requestsAndAchievementsDataSource.SelectByRequestId(request.Id).Select(dto => dto.AchievementId);
        var result = new List<AchievementDto>();
        foreach (var recordId in recordIds)
        {
            var achievement = _achievementsDataSource.SelectById(recordId);
            if (achievement == null) throw new Exception("no entity found");
            result.Add(achievement);
        }

        return result;
    } 
}