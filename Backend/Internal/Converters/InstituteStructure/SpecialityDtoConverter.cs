using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;
using Hackaton_DW_2024.Internal.Entities;

namespace Hackaton_DW_2024.Internal.Converters.InstituteStructure;

public class SpecialityDtoConverter: IConverter<Speciality, SpecialityDto>
{
    public SpecialityDto Convert(Speciality convertable)
    {
        return new SpecialityDto
        {
            Title = convertable.Title,
            FullTitle = convertable.FullTitle
        };
    }

    public Speciality ConvertBack(SpecialityDto convertable)
    {
        return new Speciality
        {
            Id = convertable.Id,
            Title = convertable.Title,
            FullTitle = convertable.FullTitle
        };
    }
}