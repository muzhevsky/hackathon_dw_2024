using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Departments;

public class EfDepartmentsDataSource: EntityFrameworkDataSource, IDepartmentsDataSource
{
    DbSet<DepartmentDto> _departments;


    public EfDepartmentsDataSource(ApplicationContext context) : base(context)
    {
        _departments = context.Departments;
    }

    public DepartmentDto? SelectById(int id)
    {
        return _departments.FirstOrDefault(dto => dto.Id == id);
    }

    public IEnumerable<DepartmentDto> SelectAll()
    {
        return _departments.ToList();
    }

    public IEnumerable<DepartmentDto> SelectByInstituteId(int instituteId)
    {
        return _departments.Where(dto => dto.InstituteId == instituteId);
    }
}