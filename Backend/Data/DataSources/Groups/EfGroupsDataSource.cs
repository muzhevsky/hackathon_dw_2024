using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Groups;

public class EfGroupsDataSource: EntityFrameworkDataSource, IGroupsDataSource
{
    DbSet<GroupDto> Groups { get; set; }
    DbSet<DepartmentDto> Departments { get; set; }

    public EfGroupsDataSource(ApplicationContext context) : base(context)
    {
        Departments = context.Departments;
        Groups = context.Groups;
    }
    
    public GroupDto? SelectById(int id)
    {
        return Groups.FirstOrDefault(dto => dto.Id == id);
    }

    public IEnumerable<GroupDto> SelectByDepartmentId(int departmentId)
    {
        return Groups.Where(dto => dto.DepartmentId == departmentId);
    }

    public void Insert(GroupDto dto)
    {
        Groups.Add(dto);
        Context.SaveChanges();
    }
}