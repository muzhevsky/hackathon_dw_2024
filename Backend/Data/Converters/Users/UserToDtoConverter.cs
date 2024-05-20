using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Internal.Entities;

namespace Hackaton_DW_2024.Data.Converters.Users;

public class UserToEfDtoConverter: IConverter<User, EfUserDto>
{
    public EfUserDto Convert(User convertable)
    {
        var dto = new EfUserDto
        {
            Login = convertable.Login,
            Surname = convertable.Surname,
            Name = convertable.Name,
            Patronymic = convertable.Patronymic,
            Password = convertable.Password,
            Salt = convertable.Salt
        };

        return dto;
    }
}