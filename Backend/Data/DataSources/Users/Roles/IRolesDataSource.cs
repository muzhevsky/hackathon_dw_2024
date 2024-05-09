using Hackaton_DW_2024.Data.Dto;

namespace Hackaton_DW_2024.Data.DataSources.Users.Roles;

public interface IRolesDataSource
{
    IEnumerable<RoleDto> SelectAll();
    RoleDto? SelectById(int id);
}