using Hackaton_DW_2024.Internal.Data.Dto.Users;

namespace Hackaton_DW_2024.Internal.Data.DataSources.Users.Roles;

public class CachedRoleDataSource : IRolesDataSource
{
    IRolesDataSource _wrappedDataSource;
    Dictionary<int, RoleDto> _cachedStorage = new();

    public CachedRoleDataSource(IRolesDataSource wrappedDataSource)
    {
        _wrappedDataSource = wrappedDataSource;
        var roles = _wrappedDataSource.SelectAll();
        foreach (var roleDto in roles)
        {
            _cachedStorage.Add(roleDto.Id, roleDto);
        }
    }

    public IEnumerable<RoleDto> SelectAll() => _cachedStorage.Select(kv => kv.Value);

    public RoleDto? SelectById(int id)
    {
        if (_cachedStorage.TryGetValue(id, out var result))
        {
            return result;
        }

        return _wrappedDataSource.SelectById(id) ?? throw new Exception("no entity found");
    }
}