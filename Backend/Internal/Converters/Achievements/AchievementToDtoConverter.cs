using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Internal.Entities;

namespace Hackaton_DW_2024.Internal.Converters.Achievements;

public class AchievementToDtoConverter : IConverter<Achievement, AchievementDto>
{
    public AchievementDto Convert(Achievement convertable)
    {
        return new AchievementDto
        {
            Score = convertable.Score,
            UserId = convertable.UserId,
            TeamSize = convertable.TeamSize,
        };
    }
}