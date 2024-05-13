﻿using Hackaton_DW_2024.Data.Dto.Users;

namespace Hackaton_DW_2024.Internal.Converters.User;

public class UserFromDtoConverter: IConverter<UserDto, Entities.Users.User>
{
    public Entities.Users.User Convert(UserDto convertable)
    {
        return new Entities.Users.User
        {
            Id = convertable.Id,
            Login = convertable.Login,
            Surname = convertable.Surname,
            Name = convertable.Name,
            Patronymic = convertable.Patronymic,
            Password = convertable.Password,
            Salt = convertable.Salt
        };
    }
}