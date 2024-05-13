using Hackaton_DW_2024.Data.Dto.Users;

namespace Hackaton_DW_2024.Internal.Converters.User;

public class UserToDtoConverter : IConverter<Entities.Users.User, UserDto>
{
    public UserDto Convert(Entities.Users.User convertable)
    {
        return new UserDto
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