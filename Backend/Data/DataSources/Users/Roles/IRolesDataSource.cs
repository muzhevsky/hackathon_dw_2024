using Hackaton_DW_2024.Data.Dto.Users;

namespace Hackaton_DW_2024.Data.DataSources.Users.Roles;

public interface IRolesDataSource
{
    IEnumerable<RoleDto> SelectAll();
    RoleDto? SelectById(int id);
}