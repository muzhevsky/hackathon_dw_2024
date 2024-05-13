﻿using Hackaton_DW_2024.Data.DataSources.Departments;
using Hackaton_DW_2024.Data.DataSources.Groups;
using Hackaton_DW_2024.Data.DataSources.Institutes;
using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;
using Hackaton_DW_2024.Internal.Entities;
using Hackaton_DW_2024.Internal.UseCases.Converters;

namespace Hackaton_DW_2024.Internal.Repositories;

public class InstituteStructureRepository
{
    IInstituteDataSource _instituteDataSource;
    IDepartmentsDataSource _departmentsDataSource;
    IGroupsDataSource _groupsDataSource;
    IConverter<DepartmentDto, Department> _departmentConverter;

    public InstituteStructureRepository(IInstituteDataSource instituteDataSource, IDepartmentsDataSource departmentsDataSource, IGroupsDataSource groupsDataSource, IConverter<DepartmentDto, Department> departmentConverter)
    {
        _instituteDataSource = instituteDataSource;
        _departmentsDataSource = departmentsDataSource;
        _groupsDataSource = groupsDataSource;
        _departmentConverter = departmentConverter;
    }

    public Institute GetInstituteById(int id)
    {
        var dto = _instituteDataSource.SelectById(id);
        if (dto == null) return null;
        return new Institute
        {
            Id = dto.Id,
            Title = dto.Title
        };
    }

    public Department? GetDepartmentById(int id)
    {
        var dto = _departmentsDataSource.SelectById(id);
        if (dto == null) return null;
        return _departmentConverter.Convert(dto);
    }

    public Group? GetGroupById(int id)
    {
        var dto = _groupsDataSource.SelectById(id);
        if (dto == null) return null;
        var depDto = _departmentsDataSource.SelectById(dto.DepartmentId);
        if (depDto == null) return null;
        return new Group
        {
            Id = dto.Id,
            DepartmentId = id,
            Department = depDto.Title,
            Title = dto.Title
        };
    }

    public List<Institute> GetAllInstitutes()
    {
        return _instituteDataSource.SelectAll()
            .Select(dto => new Institute { Title = dto.Title })
            .ToList();
    }

    public List<Department> GetDepartmentsOfInstituteId(int id)
    {
        var institute = GetInstituteById(id);
        return _departmentsDataSource.SelectByInstituteId(id).Select(dto => new Department
        {
            InstituteId = institute.Id,
            Institute = institute.Title,
            Title = dto.Title
        }).ToList();
    }

    public List<Group> GetGroupsOfDepartmentId(int id)
    {
        var department = GetDepartmentById(id);
        return _groupsDataSource.SelectByDepartmentId(id).Select(dto => new Group
        {
            DepartmentId = id,
            Department = department.Title,
            Title = dto.Title
        }).ToList();
    }
}