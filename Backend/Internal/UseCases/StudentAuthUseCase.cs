using Hackaton_DW_2024.Api.Auth;
using Hackaton_DW_2024.Api.Requests;
using Hackaton_DW_2024.Api.Responses;
using Hackaton_DW_2024.Infrastructure.Auth;
using Hackaton_DW_2024.Infrastructure.Hash;
using Hackaton_DW_2024.Internal.Entities;
using Hackaton_DW_2024.Internal.Repositories;

namespace Hackaton_DW_2024.Internal.UseCases;

public class AuthUseCase
{
    StudentRepository _studentRepository;
    UserRepository _userRepository;
    ITokenProvider _tokenRepository;
    InstituteStructureRepository _instituteStructureRepository;
    IHashProvider _hashProvider;
    ISaltProvider _saltProvider;

    public AuthUseCase(
        ITokenProvider tokenRepository,
        StudentRepository studentRepository,
        UserRepository userRepository,
        IHashProvider hashProvider,
        InstituteStructureRepository instituteStructureRepository,
        ISaltProvider saltProvider)
    {
        _tokenRepository = tokenRepository;
        _studentRepository = studentRepository;
        _hashProvider = hashProvider;
        _instituteStructureRepository = instituteStructureRepository;
        _saltProvider = saltProvider;
        _userRepository = userRepository;
    }

    public StudentSignUpResponse SignUp(StudentSignUpRequest request)
    {
        var login = $"sstudurdom/{request.StudentId}";

        if (_userRepository.GetUser(login) != null)
            throw new Exception("user already exists");

        var user = new User
        {
            Login = login,
            Password = request.Password,
            Surname = request.Surname,
            Name = request.Name,
            Patronymic = request.Patronymic
        };

        var student = new Student
        {
            Group = _instituteStructureRepository.GetGroupById(request.GroupId).Title,
            StudentId = request.StudentId
        };

        user.Salt = _saltProvider.GetSalt(0);
        user.Password = _hashProvider.Hash(user.Password + user.Salt);

        var id = _studentRepository.CreateStudent(student);

        return new StudentSignUpResponse(_tokenRepository.ProvideToken(new Dictionary<string, string>
        {
            { "id", id.ToString() }
        }));
    }

    public SignInResponse SignIn(SignInRequest request)
    {
        var user = _userRepository.GetUser(request.Login);
        if (user == null)
            throw new Exception("user not found");

        var hashedPassword = _hashProvider.Hash(request.Password + user.Salt);

        if (user.Password != hashedPassword) throw new Exception("password doesn't match");

        var role = Role.Student;
        // if (_studentRepository.GetStudentByUserId(user.Id) != null) 
        
        var userResponse = new UserResponse()
        {
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