using Hackaton_DW_2024.Data.DataSources.Departments;
using Hackaton_DW_2024.Data.DataSources.Groups;
using Hackaton_DW_2024.Data.DataSources.Institutes;
using Hackaton_DW_2024.Data.DataSources.Specialities;
using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;
using Hackaton_DW_2024.Internal.Converters;
using Hackaton_DW_2024.Internal.Entities;

namespace Hackaton_DW_2024.Infrastructure.Repositories.Database;

public class InstituteStructureRepository
{
    IInstituteDataSource _instituteDataSource;
    IDepartmentsDataSource _departmentsDataSource;
    IGroupsDataSource _groupsDataSource;
    ISpecialitiesDataSource _specialitiesDataSource;

    IConverter<Department, DepartmentDto> _departmentDtoConverter;
    IConverter<Group, GroupDto> _groupDtoConverter;
    IConverter<Institute, InstituteDto> _insituteDtoConverter;
    IConverter<Speciality, SpecialityDto> _specialityDtoConverter;

    public InstituteStructureRepository(
        IInstituteDataSource instituteDataSource,
        IDepartmentsDataSource departmentsDataSource,
        IGroupsDataSource groupsDataSource, 
        IConverter<Institute, InstituteDto> insituteDtoConverter, 
        IConverter<Group, GroupDto> groupDtoConverter, 
        IConverter<Department, DepartmentDto> departmentDtoConverter, 
        IConverter<Speciality, SpecialityDto> specialityDtoConverter, 
        ISpecialitiesDataSource specialitiesDataSource)
    {
        _instituteDataSource = instituteDataSource;
        _departmentsDataSource = departmentsDataSource;
        _groupsDataSource = groupsDataSource;
        _insituteDtoConverter = insituteDtoConverter;
        _groupDtoConverter = groupDtoConverter;
        _departmentDtoConverter = departmentDtoConverter;
        _specialityDtoConverter = specialityDtoConverter;
        _specialitiesDataSource = specialitiesDataSource;
    }

    public Institute GetInstituteById(int id)
    {
        var dto = _instituteDataSource.SelectById(id);
        if (dto == null) return null;
        return _insituteDtoConverter.ConvertBack(dto);
    }

    public Department? GetDepartmentById(int id)
    {
        var dto = _departmentsDataSource.SelectById(id);
        if (dto == null) return null;
        return _departmentDtoConverter.ConvertBack(dto);
    }

    public List<Group> GetGroups()
    {
        return _groupsDataSource.SelectAll().Select(dto => _groupDtoConverter.ConvertBack(dto)).ToList();
    }
    
    public Group? GetGroupById(int id)
    {
        var dto = _groupsDataSource.SelectById(id);
        if (dto == null) return null;
        return _groupDtoConverter.ConvertBack(dto);
    }
    
    public Speciality? GetSpecialityById(int id)
    {
        var dto = _specialitiesDataSource.SelectById(id);
        if (dto == null) return null;
        return _specialityDtoConverter.ConvertBack(dto);
    }

    public GroupDetails? GetGroupDetails(int id)
    {
        var group = GetGroupById(id);
        var department = GetDepartmentById(group.DepartmentId);
        var speciality = GetSpecialityById(group.SpecialityId);
        var institute = GetInstituteById(department.InstituteId);
        return new GroupDetails
        {
            Group = group,
            Department = department,
            Institute = institute,
            Speciality = speciality
        };
    }
    
    public List<Institute> GetAllInstitutes()
    {
        return _instituteDataSource.SelectAll()
            .Select(dto => new Institute { Title = dto.Title })
            .ToList();
    }
}