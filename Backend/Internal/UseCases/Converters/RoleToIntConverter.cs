using Hackaton_DW_2024.Internal.Data.DataSources.Users.Roles;
using Hackaton_DW_2024.Internal.Data.Dto.Users;

namespace Hackaton_DW_2024.Internal.UseCases.Converters;

public class RoleToIntConverter: IConverter<Role, int>
{
    Dictionary<Role, int> _map = new();
    IRolesDataSource _dataSource;

    public RoleToIntConverter(IRolesDataSource dataSource)
    {
        _dataSource = dataSource;
        foreach (var roleDto in _dataSource.SelectAll())
        {
            switch (roleDto.Title)
            {
                case "user":
                    _map.Add(Role.User, roleDto.Id);
                    break;
                case "admin":
                    _map.Add(Role.Admin, roleDto.Id);
                    break;
                case "deanery":
                    _map.Add(Role.Deanery, roleDto.Id);
                    break;
            }
        }
    }

    public int Convert(Role convertable)
    {
        return _map[convertable];
    }
}