using Hackaton_DW_2024.Api.Requests;
using Hackaton_DW_2024.Infrastructure.Auth;
using Hackaton_DW_2024.Infrastructure.Hash;
using Hackaton_DW_2024.Internal.Data.Dto.Users;
using Hackaton_DW_2024.Internal.Repositories;
using Hackaton_DW_2024.Internal.UseCases.Converters;

namespace Hackaton_DW_2024.Internal.UseCases;

public class AuthUseCase
{
    ITokenProvider _tokenRepository;
    UserRepository _userRepository;
    IHashProvider _hashProvider;
    IConverter<SignUpRequest, UserDto> _signUpConverter;
    IConverter<Role, int> _roleConverter;

    public AuthUseCase(
        ITokenProvider tokenRepository,
        UserRepository userRepository,
        IHashProvider hashProvider,
        IConverter<SignUpRequest, UserDto> signUpConverter, 
        IConverter<Role, int> roleConverter)
    {
        _tokenRepository = tokenRepository;
        _userRepository = userRepository;
        _hashProvider = hashProvider;
        _signUpConverter = signUpConverter;
        _roleConverter = roleConverter;
    }

    public string SignUp(SignUpRequest request)
    {
        var dto = _signUpConverter.Convert(request);
        if (_userRepository.GetUser(dto.Email) != null)
            throw new Exception("user already exists");
        
        dto.RoleId = _roleConverter.Convert(Role.User);
        dto.Salt = "SOMESALT";
        dto.Password = _hashProvider.Hash(dto.Password + dto.Salt);
        
        _userRepository.SaveUser(dto);
        
        return _tokenRepository.ProvideToken(new Dictionary<string, string>
        {
            { "id", dto.Id.ToString() }
        });
    }

    public string SignIn(SignInRequest request)
    {
        var user = _userRepository.GetUser(request.Email);
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