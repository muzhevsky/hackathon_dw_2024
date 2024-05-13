using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Internal.Entities;

namespace Hackaton_DW_2024.Internal.Converters.Achievements;

public class AchievementFromDtoConverter: IConverter<AchievementDto, Achievement>
{
    public Achievement Convert(AchievementDto convertable)
    {
        return new Achievement
        {
            Id = convertable.Id,
            Score = convertable.Score,
            TeamSize = convertable.TeamSize,
            UserId = convertable.UserId
        };
    }
}