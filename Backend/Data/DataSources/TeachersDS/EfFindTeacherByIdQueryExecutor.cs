using Hackaton_DW_2024.Data.Converters;
using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Data.Package;
using Hackaton_DW_2024.Infrastructure.Repositories;
using Hackaton_DW_2024.Internal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.TeachersDS;

public class EfFindTeacherByIdQueryExecutor: ICommandExecutor<TeacherByIdQuery, Teacher>
{
    IDbContextFactory<ApplicationContext> _contextFactory;
    IConverter<EfTeacherDto, Teacher> _converter;

    public EfFindTeacherByIdQueryExecutor(
        IDbContextFactory<ApplicationContext> contextFactory,
        IConverter<EfTeacherDto, Teacher> converter
    )
    {
        _contextFactory = contextFactory;
        _converter = converter;
    }

    public Teacher? Execute(TeacherByIdQuery query)
    {
        using var context = _contextFactory.CreateDbContext();
        var teacher = context.Teachers.FirstOrDefault(d => d.Id == query.Id);

        if (teacher == null) return null;

        return _converter.Convert(teacher);
    }
}