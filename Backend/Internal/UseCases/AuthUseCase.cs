using Hackaton_DW_2024.Api.Auth;
using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Infrastructure.Auth;
using Hackaton_DW_2024.Infrastructure.Hash;
using Hackaton_DW_2024.Infrastructure.Repositories.Database;
using Hackaton_DW_2024.Internal.Entities.Users;
using Hackaton_DW_2024.Internal.UseCases.Exceptions;

namespace Hackaton_DW_2024.Internal.UseCases;

public class AuthUseCase
{
    UserRepository _userRepository;
    StudentRepository _studentRepository;
    TeacherRepository _teacherRepository;
    ITokenProvider _tokenRepository;
    IHashProvider _hashProvider;
    ISaltProvider _saltProvider;

    public AuthUseCase(
        ITokenProvider tokenRepository,
        StudentRepository studentRepository,
        UserRepository userRepository,
        IHashProvider hashProvider,
        ISaltProvider saltProvider, 
        TeacherRepository teacherRepository)
    {
        _tokenRepository = tokenRepository;
        _studentRepository = studentRepository;
        _hashProvider = hashProvider;
        _saltProvider = saltProvider;
        _teacherRepository = teacherRepository;
        _userRepository = userRepository;
    }

    public SignUpResponse SignUpStudent(StudentSignUpRequest request)
    {
        var login = "sstuedudom/"+request.StudentId;
        var user = CreateUser(login, request.Password, request.Surname, request.Name, request.Patronymic);
        var student = new Student
        {
            GroupId = request.GroupId,
            StudentId = request.StudentId,
        };
        student.UserId = user.Id;
        
        _studentRepository.CreateStudent(student);

        var userResponse = new UserResponse()
        {
            Id = user.Id,
            Surname = user.Surname,
            Name = user.Name,
            Patronymic = user.Patronymic,
            Role = "student"
        };

        return new SignUpResponse(userResponse, _tokenRepository.ProvideToken(new TokenClaims(user.Id)));
    }

    public SignInResponse SignIn(SignInRequest request)
    {
        var user = _userRepository.GetUser(request.Login);
        if (user == null) throw new AuthException("user not found");

        if (!user.PasswordMatches(request.Password)) throw new AuthException("wrong password");
        
        var role = "student";
        if (_teacherRepository.GetTeacherByUserId(user.Id) != null) role = "teacher"; 

        var userResponse = new UserResponse()
        {
            Id = user.Id,
            Surname = user.Surname,
            Name = user.Name,
            Patronymic = user.Patronymic,
            Role = role
        };

        return new SignInResponse(userResponse, _tokenRepository.ProvideToken(new TokenClaims(user.Id)));
    }

    public SignUpResponse SignUpTeacher(TeacherSignUpRequest request)
    {
        Console.WriteLine(request.DepartmentId);
        var user = CreateUser(request.Login, request.Password, request.Surname, request.Name, request.Patronymic);
        var teacher = new TeacherDto
        {
            UserId = user.Id,
            DepartmentId = request.DepartmentId
        };
        teacher.UserId = user.Id;
        _teacherRepository.CreateTeacher(teacher);
        
        var userResponse = new UserResponse()
        {
            Id = user.Id,
            Surname = user.Surname,
            Name = user.Name,
            Patronymic = user.Patronymic,
            Role = "teacher"
        };

        return new SignUpResponse(userResponse, _tokenRepository.ProvideToken(new TokenClaims(user.Id)));
    }

    User CreateUser(string login, string password, string surname, string name, string patronymic)
    {
        var user = new User
        {
            Login = login,
            Password = password,
            Surname = surname,
            Name = name,
            Patronymic = patronymic
        };

        if (_userRepository.GetUser(user.Login) != null) throw new AuthException("user already exist");

        _userRepository.CreateUser(user);

        return user;
    }
}