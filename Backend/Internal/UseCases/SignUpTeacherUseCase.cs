using Hackaton_DW_2024.Api.Auth;
using Hackaton_DW_2024.Infrastructure.Auth;
using Hackaton_DW_2024.Infrastructure.Hash;
using Hackaton_DW_2024.Infrastructure.Repositories;
using Hackaton_DW_2024.Internal.Entities;
using Hackaton_DW_2024.Internal.UseCases.Exceptions;

namespace Hackaton_DW_2024.Internal.UseCases;

public class SignUpTeacherUseCase
{
    UsersRepository _usersRepository;
    TeachersRepository _teachersRepository;
    ITokenProvider _tokenRepository;
    IHashProvider _hashProvider;
    ISaltProvider _saltProvider;

    public SignUpTeacherUseCase(
        TeachersRepository teachersRepository,
        IHashProvider hashProvider,
        ISaltProvider saltProvider,
        UsersRepository usersRepository,
        ITokenProvider tokenRepository)
    {
        _teachersRepository = teachersRepository;
        _hashProvider = hashProvider;
        _saltProvider = saltProvider;
        _usersRepository = usersRepository;
        _tokenRepository = tokenRepository;
    }

    public SignUpResponse SignUpTeacher(TeacherSignUpRequest request)
    {
        CheckUserLogin(request.Login);
        var user = new User
        {
            Surname = request.Surname,
            Name = request.Name,
            Patronymic = request.Patronymic,
            Login = request.Login,
            Password = request.Password
        };

        HandlePassword(user);
        
        var teacher = new Teacher
        {
            DepartmentId = request.DepartmentId
        };

        _teachersRepository.CreateTeacherWithUser(teacher, user);
        
        var userResponse = new UserResponse()
        {
            Id = user.Id,
            Surname = user.Surname,
            Name = user.Name,
            Patronymic = user.Patronymic,
        };

        return new SignUpResponse(userResponse, _tokenRepository.ProvideToken(new TokenClaims(user.Id)));
    }

    void CheckUserLogin(string login)
    {
        var exists = _usersRepository.GetUserByLogin(login) != null;
        if (exists) throw new DuplicateEntityException("teacher with this login already exists");
    }

    void HandlePassword(User user)
    {
        var salt = _saltProvider.GetSalt(8);
        user.Password = _hashProvider.Hash(user.Password + salt);
        user.Salt = salt;
    }
}