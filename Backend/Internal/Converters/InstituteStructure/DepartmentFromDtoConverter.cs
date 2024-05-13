using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;
using Hackaton_DW_2024.Internal.Entities;

namespace Hackaton_DW_2024.Internal.Converters.InstituteStructure;

public class DepartmentFromDtoConverter:IConverter<DepartmentDto, Department>
{
    IConverter<InstituteDto, Institute> _instituteConverter;

    public DepartmentFromDtoConverter(IConverter<InstituteDto, Institute> instituteConverter)
    {
        _instituteConverter = instituteConverter;
    }

    public Department Convert(DepartmentDto convertable)
    {
        return new Department
        {
            Id = convertable.Id,
            InstituteId = convertable.InstituteId,
            Title = convertable.Title
        };
    }
}