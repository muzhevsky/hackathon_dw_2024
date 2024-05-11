using Hackaton_DW_2024.Internal.Data.Config;
using Hackaton_DW_2024.Internal.Data.Dto.Users;
using Hackaton_DW_2024.Internal.Data.Package;
using Microsoft.EntityFrameworkCore;
using ILogger = Hackaton_DW_2024.Infrastructure.Logging.ILogger;

namespace Hackaton_DW_2024.Internal.Data.DataSources.Users.Roles;

public class EfRolesDataSource : EntityFrameworkDataSource, IRolesDataSource
{
    protected DbSet<RoleDto> Roles { get; set; }

    public EfRolesDataSource(DatabaseConnectionConfig config, ILogger logger) : base(config, logger)
    {
    }

    public IEnumerable<RoleDto> SelectAll() => Roles.ToList();

    public RoleDto? SelectById(int id) => Roles.FirstOrDefault(dto => dto.Id == id);
}