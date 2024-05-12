using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Internal.Entities;

namespace Hackaton_DW_2024.Internal.UseCases.Converters;

public class UserFromDtoConverter: IConverter<UserDto, User>
{
    public User Convert(UserDto convertable)
    {
        return new User
        {
            Login = convertable.Login,
            Surname = convertable.Surname,
            Name = convertable.Name,
            Patronymic = convertable.Patronymic,
            Password = convertable.Password,
            Salt = convertable.Salt
        };
    }
}