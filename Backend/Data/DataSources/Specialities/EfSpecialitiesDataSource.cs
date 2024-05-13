using System.Xml;
using Hackaton_DW_2024.Data.DataSources.Achievements;
using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Specialities;

public class EfSpecialitiesDataSource: EfAchievementsDataSource, ISpecialitiesDataSource
{
    DbSet<SpecialityDto> _specialities;   
    public EfSpecialitiesDataSource(ApplicationContext context) : base(context)
    {
        _specialities = context.Specialities;
    }
    
    public SpecialityDto? GetById(int id)
    {
        return _specialities.FirstOrDefault(dto => dto.Id == id);
    }

    public IEnumerable<SpecialityDto> GetAll()
    {
        return _specialities.ToList();
    }

    public void Insert(SpecialityDto speciality)
    {
        _specialities.Add(speciality);
        Context.SaveChanges();
    }
}