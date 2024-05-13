using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Specialities;

public class EfSpecialitiesDataSource: EntityFrameworkDataSource, ISpecialitiesDataSource
{
    DbSet<SpecialityDto> _specialities;   
    public EfSpecialitiesDataSource(ApplicationContext context) : base(context)
    {
        _specialities = context.Specialities;
    }
    
    public SpecialityDto? SelectById(int id)
    {
        return _specialities.FirstOrDefault(dto => dto.Id == id);
    }

    public IEnumerable<SpecialityDto> SelectAll()
    {
        return _specialities.ToList();
    }

    public void Insert(SpecialityDto speciality)
    {
        _specialities.Add(speciality);
        Context.SaveChanges();
    }
}