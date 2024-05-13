using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;
using Hackaton_DW_2024.Internal.Entities;

namespace Hackaton_DW_2024.Internal.UseCases.Converters.InstituteStructure;

public class GroupFromDtoConverter:IConverter<GroupDto, Group>
{
    IConverter<DepartmentDto, Department> _departmentConverter;

    public GroupFromDtoConverter(IConverter<DepartmentDto, Department> departmentConverter)
    {
        _departmentConverter = departmentConverter;
    }

    public Group Convert(GroupDto convertable)
    {
        return new Group
        {
            Id = convertable.Id,
            Title = convertable.Title,
            DepartmentId = convertable.DepartmentId
        };
    }
}