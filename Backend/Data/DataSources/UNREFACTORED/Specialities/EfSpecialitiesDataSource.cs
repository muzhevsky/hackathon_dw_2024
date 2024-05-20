using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.UNREFACTORED.Specialities;

public class EfSpecialitiesDataSource:  ISpecialitiesDataSource
{
    IDbContextFactory<ApplicationContext> _factory;
    public EfSpecialitiesDataSource(IDbContextFactory<ApplicationContext>  context)
    {
        _factory = context;
    }
    
    public SpecialityDto? SelectById(int id)
    {
        using var context = _factory.CreateDbContext();
        return context.Specialities.FirstOrDefault(dto => dto.Id == id);
    }

    public IEnumerable<SpecialityDto> SelectAll()
    {
        using var context = _factory.CreateDbContext();
        return context.Specialities.ToList();
    }

    public void Insert(SpecialityDto speciality)
    {
        using var context = _factory.CreateDbContext();
        context.Specialities.Add(speciality);
        context.SaveChanges();
    }
}