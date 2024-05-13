using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;

namespace Hackaton_DW_2024.Data.DataSources.Specialities;

public interface ISpecialitiesDataSource
{
    SpecialityDto? GetById(int id);
    IEnumerable<SpecialityDto> GetAll();
    void Insert(SpecialityDto speciality);
}