using Hackaton_DW_2024.Data.Converters;
using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Data.Package;
using Hackaton_DW_2024.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.UsersDS;

public class EfFindUserByLoginQueryExecutor: ICommandExecutor<UserByLoginQuery, Internal.Entities.User>
{
    IDbContextFactory<ApplicationContext> _contextFactory;
    IConverter<EfUserDto, Internal.Entities.User> _converter;

    public EfFindUserByLoginQueryExecutor(IDbContextFactory<ApplicationContext> contextFactory, IConverter<EfUserDto, Internal.Entities.User> converter)
    {
        _contextFactory = contextFactory;
        _converter = converter;
    }

    public Internal.Entities.User? Execute(UserByLoginQuery query)
    {
        using var context = _contextFactory.CreateDbContext();
        var dto = context.Users.FirstOrDefault(d => d.Login == query.Login);

        if (dto == null) return null;

        return _converter.Convert(dto);
    }
}
