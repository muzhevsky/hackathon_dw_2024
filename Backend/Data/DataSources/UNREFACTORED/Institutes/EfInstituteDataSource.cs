using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.UNREFACTORED.Institutes;

public class EfInstituteDataSource:  IInstituteDataSource
{
    IDbContextFactory<ApplicationContext> _factory;
    
    public EfInstituteDataSource(IDbContextFactory<ApplicationContext>  context)
    {
        _factory = context;
    }

    public IEnumerable<InstituteDto> SelectAll()
    {
        using var context = _factory.CreateDbContext();
        return context.Institutes;
    }

    public InstituteDto? SelectById(int id)
    {
        using var context = _factory.CreateDbContext();
        return context.Institutes.FirstOrDefault(dto => dto.Id == id);
    }
}