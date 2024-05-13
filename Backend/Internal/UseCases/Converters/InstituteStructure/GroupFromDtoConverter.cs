using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;
using Hackaton_DW_2024.Internal.Entities;

namespace Hackaton_DW_2024.Internal.UseCases.Converters.InstituteStructure;

public class GroupToDtoConverter:IConverter<Group, GroupDto>
{
    IConverter<Department, DepartmentDto> _departmentConverter;

    public GroupToDtoConverter(IConverter<Department, DepartmentDto> departmentConverter)
    {
        _departmentConverter = departmentConverter;
    }

    public GroupDto Convert(Group convertable)
    {
        return new GroupDto
        {
            Id = convertable.Id,
            Title = convertable.Title,
            DepartmentId = convertable.DepartmentId
        };
    }
}