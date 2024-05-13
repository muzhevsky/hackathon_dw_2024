using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;
using Hackaton_DW_2024.Internal.Entities;

namespace Hackaton_DW_2024.Internal.Converters.InstituteStructure;

public class InstituteFromDtoConverter: IConverter<InstituteDto, Institute>
{
    public Institute Convert(InstituteDto convertable)
    {
        return new Institute
        {
            Id = convertable.Id,
            Title = convertable.Title
        };
    }
}