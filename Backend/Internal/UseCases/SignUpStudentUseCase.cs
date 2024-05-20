using Hackaton_DW_2024.Api.Auth;
using Hackaton_DW_2024.Infrastructure.Auth;
using Hackaton_DW_2024.Infrastructure.Hash;
using Hackaton_DW_2024.Infrastructure.Repositories;
using Hackaton_DW_2024.Internal.Entities;
using Hackaton_DW_2024.Internal.UseCases.Exceptions;

namespace Hackaton_DW_2024.Internal.UseCases;

public class SignUpStudentUseCase
{
    UsersRepository _usersRepository;
    StudentsRepository _studentsRepository;
    ITokenProvider _tokenRepository;
    IHashProvider _hashProvider;
    ISaltProvider _saltProvider;

    public SignUpStudentUseCase(
        UsersRepository usersRepository,
        StudentsRepository studentsRepository,
        ITokenProvider tokenRepository,
        IHashProvider hashProvider,
        ISaltProvider saltProvider
    )
    {
        _tokenRepository = tokenRepository;
        _hashProvider = hashProvider;
        _saltProvider = saltProvider;
        _usersRepository = usersRepository;
        _studentsRepository = studentsRepository;
    }

    public SignUpResponse SignUpStudent(StudentSignUpRequest request)
    {
        CheckStudentId(request.StudentId);

        var user = new User
        {
            Surname = request.Surname,
            Name = request.Name,
            Patronymic = request.Patronymic,
            Password = request.Password
        };

        HandleLogin(user, request.StudentId);
        CheckUserLogin(user.Login);
        HandlePassword(user);

        var student = new Student
        {
            StudentId = request.StudentId,
            GroupId = request.GroupId,
            Telegram = request.Telegram,
            PhoneNumber = request.PhoneNumber
        };

        _studentsRepository.CreateStudent(student, user);

        var userResponse = new UserResponse()
        {
            Id = user.Id,
            Surname = user.Surname,
            Name = user.Name,
            Patronymic = user.Patronymic
        };

        return new SignUpResponse(userResponse, _tokenRepository.ProvideToken(new TokenClaims(user.Id)));
    }

    void CheckStudentId(string studentId)
    {
        var exists = _studentsRepository.GetStudentByStudentId(studentId) != null;
        if (exists) throw new DuplicateEntityException("student with this studentId already exists");
    }

    void CheckUserLogin(string login)
    {
        var exists = _usersRepository.GetUserByLogin(login) != null;
        if (exists) throw new DuplicateEntityException("student with this login already exists");
    }

    void HandleLogin(User user, string studentId)
    {
        user.Login = "sstuedudom/" + studentId;
    }

    void HandlePassword(User user)
    {
        var salt = _saltProvider.GetSalt(8);
        user.Password = _hashProvider.Hash(user.Password + salt);
        user.Salt = salt;
    }
}