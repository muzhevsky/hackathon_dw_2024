using Hackaton_DW_2024.Data.DataSources.Groups;
using Hackaton_DW_2024.Data.DataSources.Institutes;
using Hackaton_DW_2024.Data.DataSources.Specialities;
using Hackaton_DW_2024.Data.DataSources.Students;
using Hackaton_DW_2024.Data.DataSources.Users;
using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;
using Hackaton_DW_2024.Internal.Converters;
using Hackaton_DW_2024.Internal.Entities;
using Hackaton_DW_2024.Internal.Entities.Users;

namespace Hackaton_DW_2024.Infrastructure.Repositories.Database;

public class StudentRepository
{
    IStudentsDataSource _studentsDataSource;
    IUsersDataSource _usersDataSource;
    IGroupsDataSource _groupsDataSource;
    IConverter<Student, StudentDto> _studentDtoConverter;
    IConverter<Group, GroupDto> _groupDtoConverter;
    IConverter<User, UserDto> _userDtoConverter;

    public StudentRepository(
        IStudentsDataSource studentsDataSource, 
        IConverter<Student, StudentDto> studentDtoConverter, 
        IGroupsDataSource groupsDataSource, 
        IUsersDataSource usersDataSource,
        IConverter<Group, GroupDto> groupDtoConverter, 
        IConverter<User, UserDto> userDtoConverter)
    {
        _studentsDataSource = studentsDataSource;
        _studentDtoConverter = studentDtoConverter;
        _groupsDataSource = groupsDataSource;
        _usersDataSource = usersDataSource;
        _groupDtoConverter = groupDtoConverter;
        _userDtoConverter = userDtoConverter;
    }

    public void CreateStudent(Student student)
    {
        var id = _studentsDataSource.Insert(_studentDtoConverter.Convert(student));
        student.Id = id;
    }

    public Student? GetStudent(int id)
    {
        var dto = _studentsDataSource.SelectById(id);
        if (dto == null) return null;

        var student = _studentDtoConverter.ConvertBack(dto);
        return student;
    }

    public StudentDetails? GetStudentDetailsByUserId(int id)
    {
        var student = _studentsDataSource.SelectByUserId(id);
        if (student == null) return null;
        var user = _usersDataSource.SelectById(student.UserId);
        var group = _groupsDataSource.SelectById(student.GroupId);
        return new StudentDetails
        {
            Group = _groupDtoConverter.ConvertBack(group),
            Student = _studentDtoConverter.ConvertBack(student),
            User = _userDtoConverter.ConvertBack(user)
        };
    }

    public Student? GetStudentByUserId(int userId)
    {
        var dto = _studentsDataSource.SelectByUserId(userId);
        if (dto == null) return null;
        
        var student = _studentDtoConverter.ConvertBack(dto);
        return student;
    }
}