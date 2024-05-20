using Hackaton_DW_2024.Data.Converters;
using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Data.Package;
using Hackaton_DW_2024.Infrastructure.Repositories;
using Hackaton_DW_2024.Internal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.UsersDS;

public class EfCreateUserExecutor : ICommandExecutor<User, int>
{
    IDbContextFactory<ApplicationContext> _contextFactory;
    IConverter<User, EfUserDto> _converter;

    public EfCreateUserExecutor(IDbContextFactory<ApplicationContext> contextFactory, IConverter<User, EfUserDto> converter)
    {
        _contextFactory = contextFactory;
        _converter = converter;
    }

    public int Execute(User user)
    {
        using var context = _contextFactory.CreateDbContext();
        var dto = _converter.Convert(user);

        context.Users.Add(dto);
        context.SaveChanges();

        return dto.Id;
    }
}
