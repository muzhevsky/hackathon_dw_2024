using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Internal.Entities;
using File = Hackaton_DW_2024.Internal.Entities.File;

namespace Hackaton_DW_2024.Internal.UseCases.Converters.Achievements;

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