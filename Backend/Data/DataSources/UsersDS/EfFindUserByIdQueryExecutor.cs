using Hackaton_DW_2024.Data.Converters;
using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Data.Package;
using Hackaton_DW_2024.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.UsersDS;

public class EfFindUserByIdQueryExecutor: ICommandExecutor<UserByIdQuery, Internal.Entities.User>
{
    IDbContextFactory<ApplicationContext> _contextFactory;
    IConverter<EfUserDto, Internal.Entities.User> _converter;

    public EfFindUserByIdQueryExecutor(IDbContextFactory<ApplicationContext> contextFactory, IConverter<EfUserDto, Internal.Entities.User> converter)
    {
        _contextFactory = contextFactory;
        _converter = converter;
    }

    public Internal.Entities.User? Execute(UserByIdQuery query)
    {
        using var context = _contextFactory.CreateDbContext();
        var user = context.Users.FirstOrDefault(d => d.Id == query.Id);

        if (user == null) return null;

        return _converter.Convert(user);
    }
}