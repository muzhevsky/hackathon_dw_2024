using Hackaton_DW_2024.Api.Auth;
using Hackaton_DW_2024.Infrastructure.Auth;
using Hackaton_DW_2024.Infrastructure.Hash;
using Hackaton_DW_2024.Infrastructure.Repositories;
using Hackaton_DW_2024.Internal.UseCases.Exceptions;

namespace Hackaton_DW_2024.Internal.UseCases;

public class SignInUseCase
{
    UsersRepository _usersRepository;
    ITokenProvider _tokenRepository;
    IHashProvider _hashProvider;

    public SignInUseCase(
        UsersRepository usersRepository,
        ITokenProvider tokenRepository,
        IHashProvider hashProvider)
    {
        _tokenRepository = tokenRepository;
        _hashProvider = hashProvider;
        _usersRepository = usersRepository;
    }

    public SignInResponse SignIn(SignInRequest request)
    {
        var user = _usersRepository.GetUserByLogin(request.Login);
        if (user == null) throw new EntityNotFoundException("no student found with such a login");

        if (!user.CheckPassword(_hashProvider.Hash(request.Password + user.Salt)))
        {
            throw new AuthException("wrong password");
        }

        var userResponse = new UserResponse()
        {
            Id = user.Id,
            Surname = user.Surname,
            Name = user.Name,
            Patronymic = user.Patronymic,
        };

        return new SignInResponse(userResponse, _tokenRepository.ProvideToken(new TokenClaims(user.Id)));
    }
}