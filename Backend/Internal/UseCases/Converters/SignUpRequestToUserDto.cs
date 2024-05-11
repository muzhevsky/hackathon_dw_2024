using Hackaton_DW_2024.Api.Requests;
using Hackaton_DW_2024.Internal.Data.Dto.Users;

namespace Hackaton_DW_2024.Internal.UseCases.Converters;

public class SignUpRequestToUserDto : IConverter<SignUpRequest, UserDto>
{
    public UserDto Convert(SignUpRequest convertable)
    {
        return new UserDto()
        {
            Email = convertable.Email,
            Password = convertable.Password,
            Surname = convertable.Surname,
            Name = convertable.Name,
            Patronymic = convertable.Patronymic
        };
    }
}