using Hackaton_DW_2024.Data.Converters;
using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Data.Package;
using Hackaton_DW_2024.Infrastructure.Repositories;
using Hackaton_DW_2024.Internal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.TeachersDS;

public class EfCreateTeacherExecutor : ICommandExecutor<Teacher, int>
{
    IDbContextFactory<ApplicationContext> _contextFactory;
    IConverter<Teacher, EfTeacherDto> _converter;

    public EfCreateTeacherExecutor(
        IDbContextFactory<ApplicationContext> contextFactory,
        IConverter<Teacher, EfTeacherDto> converter
    )
    {
        _contextFactory = contextFactory;
        _converter = converter;
    }

    public int Execute(Teacher teacher)
    {
        using var context = _contextFactory.CreateDbContext();
        var dto = _converter.Convert(teacher);

        context.Teachers.Add(dto);
        context.SaveChanges();
        return dto.Id;
    }
}