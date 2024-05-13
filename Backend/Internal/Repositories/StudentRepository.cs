using Hackaton_DW_2024.Data.DataSources.Groups;
using Hackaton_DW_2024.Data.DataSources.Students;
using Hackaton_DW_2024.Data.DataSources.Users;
using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Internal.Entities;
using Hackaton_DW_2024.Internal.UseCases.Converters;

namespace Hackaton_DW_2024.Internal.Repositories;

public class StudentRepository
{
    IConverter<StudentDto, Student?> _studentsFromDtoConverter;
    IConverter<Student, StudentDto> _studentsToDtoConverter;
    IStudentsDataSource _studentsDataSource;
    IUsersDataSource _usersDataSource;
    IGroupsDataSource _groupsDataSource;

    public StudentRepository(
        IStudentsDataSource studentsDataSource, 
        IConverter<Student, StudentDto> studentsToDtoConverter, 
        IConverter<StudentDto, Student?> studentsFromDtoConverter, 
        IUsersDataSource usersDataSource,
        IGroupsDataSource groupsDataSource)
    {
        _studentsDataSource = studentsDataSource;
        _studentsToDtoConverter = studentsToDtoConverter;
        _studentsFromDtoConverter = studentsFromDtoConverter;
        _usersDataSource = usersDataSource;
        _groupsDataSource = groupsDataSource;
    }

    public int CreateStudent(Student student)
    {
        var id = _studentsDataSource.Insert(_studentsToDtoConverter.Convert(student));
        return _studentsDataSource.SelectById(id)!.Id;
    }

    public Student? GetStudent(int id)
    {
        var dto = _studentsDataSource.SelectById(id);
        if (dto == null) return null;
        return _studentsFromDtoConverter.Convert(dto);
    }

    public Student? GetStudentByUserId(int userId)
    {
        var dto = _studentsDataSource.SelectByUserId(userId);
        if (dto == null) return null;
        dto.User = _usersDataSource.SelectById(dto.UserId);
        dto.Group = _groupsDataSource.SelectById(dto.GroupId);
        var student = _studentsFromDtoConverter.Convert(dto);
        student.Surname = dto.User.Surname;
        student.Name = dto.User.Surname;
        student.Patronymic = dto.User.Patronymic;
        return student;
    }
}