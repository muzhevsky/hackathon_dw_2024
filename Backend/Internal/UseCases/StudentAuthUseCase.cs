using Hackaton_DW_2024.Api.Auth;
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

    public SignUpResponse SignUpStudent(SignUpRequest request)
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

        if (_userRepository.GetUser(user.Login) != null) throw new AuthException("user already exist");
        
        var student = new Student
        {
            GroupId = request.GroupId,
            StudentId = request.StudentId,
        };

        var salt = _saltProvider.GetSalt(8);
        var hashed = _hashProvider.Hash(user.Password + salt);
        user.SetHashedPassword(hashed, salt);

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

        return new SignUpResponse(userResponse, _tokenRepository.ProvideToken(new TokenClaims(user.Id)));
    }

    public SignInResponse SignIn(SignInRequest request)
    {
        var user = _userRepository.GetUser(request.Login);
        if (user == null) throw new AuthException("user not found");

        var hashedPassword = _hashProvider.Hash(request.Password + user.Salt);

        if (!user.PasswordMatches(hashedPassword)) throw new AuthException("wrong password");

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

        return new SignInResponse(userResponse, _tokenRepository.ProvideToken(new TokenClaims(user.Id)));
    }
}