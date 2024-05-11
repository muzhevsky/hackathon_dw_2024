using Hackaton_DW_2024.Internal.Data.Dto.Users;

namespace Hackaton_DW_2024.Internal.Data.DataSources.Users.Roles;

public interface IRolesDataSource
{
    IEnumerable<RoleDto> SelectAll();
    RoleDto? SelectById(int id);
}