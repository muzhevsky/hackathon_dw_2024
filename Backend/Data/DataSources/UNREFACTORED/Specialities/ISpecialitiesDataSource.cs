using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;

namespace Hackaton_DW_2024.Data.DataSources.UNREFACTORED.Specialities;

public interface ISpecialitiesDataSource
{
    SpecialityDto? SelectById(int id);
    IEnumerable<SpecialityDto> SelectAll();
    void Insert(SpecialityDto speciality);
}