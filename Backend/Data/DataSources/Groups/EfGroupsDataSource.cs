using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Groups;

public class EfGroupsDataSource:  IGroupsDataSource
{
    IDbContextFactory<ApplicationContext> _factory;
    public EfGroupsDataSource(IDbContextFactory<ApplicationContext>  context)
    {
        _factory = context;
    }
    
    public GroupDto? SelectById(int id)
    {
        using var context = _factory.CreateDbContext();
        return context.Groups.FirstOrDefault(dto => dto.Id == id);
    }

    public IEnumerable<GroupDto> SelectAll()
    {
        using var context = _factory.CreateDbContext();
        return context.Groups.ToList();
    }

    public IEnumerable<GroupDto> SelectByDepartmentId(int departmentId)
    {
        using var context = _factory.CreateDbContext();
        return context.Groups.Where(dto => dto.DepartmentId == departmentId);
    }

    public void Insert(GroupDto dto)
    {
        using var context = _factory.CreateDbContext();
        context.Groups.Add(dto);
        context.SaveChanges();
    }
}