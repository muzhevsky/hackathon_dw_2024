using Hackaton_DW_2024.Data.Dto;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Users.Roles;

public class EFRolesDataSource : EntityFrameworkDataSource, IRolesDataSource
{
    protected DbSet<RoleDto> Roles { get; set; }

    public EFRolesDataSource(DatabaseConnectionConfig config) : base(config)
    {
    }

    public IEnumerable<RoleDto> SelectAll() => Roles.ToList();

    public RoleDto? SelectById(int id) => Roles.FirstOrDefault(dto => dto.Id == id);
}