using Hackaton_DW_2024.Api.Requests;
using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Infrastructure.Auth;
using Hackaton_DW_2024.Infrastructure.Hash;
using Hackaton_DW_2024.Internal.Entities;
using Hackaton_DW_2024.Internal.Repositories;
using Hackaton_DW_2024.Internal.UseCases.Converters;

namespace Hackaton_DW_2024.Internal.UseCases;

public class UserAuthUseCase
{
    ITokenProvider _tokenRepository;
    StudentRepository _studentRepository;
    InstituteStructureRepository _instituteStructureRepository;
    IHashProvider _hashProvider;
    ISaltProvider _saltProvider;

    public UserAuthUseCase(
        ITokenProvider tokenRepository,
        StudentRepository studentRepository,
        IHashProvider hashProvider, 
        InstituteStructureRepository instituteStructureRepository, 
        ISaltProvider saltProvider)
    {
        _tokenRepository = tokenRepository;
        _studentRepository = studentRepository;
        _hashProvider = hashProvider;
        _instituteStructureRepository = instituteStructureRepository;
        _saltProvider = saltProvider;
    }

    public string SignUp(StudentSignUpRequest request)
    {
        var login = $"sstudurdom/{request.StudentId}";
        
        if (_studentRepository.GetUser(login) != null)
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
            UserData = user,
            Group = _instituteStructureRepository.GetGroupById(request.GroupId),
            StudentId = request.StudentId
        };
        
        user.Salt = _saltProvider.GetSalt(0);
        user.Password = _hashProvider.Hash(user.Password + user.Salt);
        
        var id = _studentRepository.CreateStudent(student);
        
        return _tokenRepository.ProvideToken(new Dictionary<string, string>
        {
            { "id", id.ToString() }
        });
    }

    public string SignIn(SignInRequest request)
    {
        var user = _studentRepository.GetUser(request.Login);
        if (user == null) 
            throw new Exception("user not found");
        
        var hashedPassword = _hashProvider.Hash(request.Password+user.Salt);
        
        if (user.Password != hashedPassword) throw new Exception("password doesn't match");
        
        return _tokenRepository.ProvideToken(new Dictionary<string, string>()
        {
            { "id", user.Id.ToString() }
        });
    }
}