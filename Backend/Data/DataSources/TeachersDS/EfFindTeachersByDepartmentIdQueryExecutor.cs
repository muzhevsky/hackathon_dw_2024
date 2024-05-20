using Hackaton_DW_2024.Data.Converters;
using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Data.Package;
using Hackaton_DW_2024.Infrastructure.Repositories;
using Hackaton_DW_2024.Internal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.TeachersDS;

public class EfFindTeachersByDepartmentIdQueryExecutor: ICommandExecutor<TeacherByDepartmentIdQuery, List<Teacher>>
{
    IDbContextFactory<ApplicationContext> _contextFactory;
    IConverter<EfTeacherDto, Teacher> _converter;

    public EfFindTeachersByDepartmentIdQueryExecutor(IDbContextFactory<ApplicationContext> contextFactory, IConverter<EfTeacherDto, Teacher> converter)
    {
        _contextFactory = contextFactory;
        _converter = converter;
    }

    public List<Teacher> Execute(TeacherByDepartmentIdQuery query)
    {
        using var context = _contextFactory.CreateDbContext();
        var teachers = context.Teachers.Where(d => d.DepartmentId == query.DepartmentId);

        return teachers.Select(t => _converter.Convert(t)).ToList();
    }
}