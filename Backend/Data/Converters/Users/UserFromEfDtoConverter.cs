using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Internal.Entities;

namespace Hackaton_DW_2024.Data.Converters.Users;

public class UserFromEfDtoConverter: IConverter<EfUserDto, User>
{
    public User Convert(EfUserDto convertable)
    {
        return new User
        {
            Login = convertable.Login,
            Surname = convertable.Surname,
            Name = convertable.Name,
            Patronymic = convertable.Patronymic,
            Id = convertable.Id,
            Password = convertable.Password,
            Salt = convertable.Salt
        };
    }
}