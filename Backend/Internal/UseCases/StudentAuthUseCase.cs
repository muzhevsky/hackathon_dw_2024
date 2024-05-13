using Hackaton_DW_2024.Api.Auth;
using Hackaton_DW_2024.Infrastructure.Auth;
using Hackaton_DW_2024.Infrastructure.Hash;
using Hackaton_DW_2024.Internal.Entities.Users;
using Hackaton_DW_2024.Internal.Repositories;
using Hackaton_DW_2024.Internal.Repositories.Database;

namespace Hackaton_DW_2024.Internal.UseCases;

public class AuthUseCase
{
    UserRepository _userRepository;
    StudentRepository _studentRepository;
    ITokenProvider _tokenRepository;
    IHashProvider _hashProvider;
    ISaltProvider _saltProvider;

    public AuthUseCase(
        ITokenProvider tokenRepository,
        StudentRepository studentRepository,
        UserRepository userRepository,
        IHashProvider hashProvider,
        ISaltProvider saltProvider)
    {
        _tokenRepository = tokenRepository;
        _studentRepository = studentRepository;
        _hashProvider = hashProvider;
        _saltProvider = saltProvider;
        _userRepository = userRepository;
    }

    public StudentSignUpResponse SignUpStudent(StudentSignUpRequest request)
    {
        var login = request.StudentId;

        var user = new User
        {
            Login = login,
            Password = request.Password,
            Surname = request.Surname,
            Name = request.Name,
            Patronymic = request.Patronymic
        };

        if (_userRepository.GetUser(login) != null)
            throw new Exception("user already exists");
        
        var student = new Student
        {
            GroupId = request.GroupId,
            StudentId = request.StudentId,
        };
        
        user.Salt = _saltProvider.GetSalt(8);
        user.Password = _hashProvider.Hash(user.Password + user.Salt);

        _userRepository.CreateUser(user);
        student.UserId = user.Id;
        _studentRepository.CreateStudent(student);
        
        var userResponse = new UserResponse()
        {
            Id = user.Id,
            Surname = user.Surname,
            Name = user.Name,
            Patronymic = user.Patronymic,
            Role = (int)Role.Student
        };

        return new StudentSignUpResponse(
            userResponse,
            _tokenRepository.ProvideToken(new Dictionary<string, string>
            {
                { "id", user.Id.ToString() }
            }));
    }

    public SignInResponse SignIn(SignInRequest request)
    {
        var user = _userRepository.GetUser(request.Login);
        if (user == null) throw new Exception("user not found");

        var hashedPassword = _hashProvider.Hash(request.Password + user.Salt);

        if (!user.PasswordMatches(hashedPassword)) throw new Exception("password doesn't match");

        var role = Role.Student;
        //if (_studentRepository.GetStudentByUserId(user.Id) != null)  todo проверять на препода / админа  / деканат 

        var userResponse = new UserResponse()
        {
            Id = user.Id,
            Surname = user.Surname,
            Name = user.Name,
            Patronymic = user.Patronymic,
            Role = (int)role
        };

        return new SignInResponse(
            userResponse,
            _tokenRepository.ProvideToken(new Dictionary<string, string>()
            {
                { "id", user.Id.ToString() }
            }));
    }
}