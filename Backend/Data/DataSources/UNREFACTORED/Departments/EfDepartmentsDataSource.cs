using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.UNREFACTORED.Departments;

public class EfDepartmentsDataSource:  IDepartmentsDataSource
{
    IDbContextFactory<ApplicationContext> _factory;

    public EfDepartmentsDataSource(IDbContextFactory<ApplicationContext>  context)
    {
        _factory = context;
    }

    public DepartmentDto? SelectById(int id)
    {
        using var context = _factory.CreateDbContext();
        return context.Departments.FirstOrDefault(dto => dto.Id == id);
    }

    public IEnumerable<DepartmentDto> SelectAll()
    {
        using var context = _factory.CreateDbContext();
        return context.Departments.ToList();
    }

    public IEnumerable<DepartmentDto> SelectByInstituteId(int instituteId)
    {
        using var context = _factory.CreateDbContext();
        return context.Departments.Where(dto => dto.InstituteId == instituteId).ToList();
    }
}