﻿using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;
using ILogger = Hackaton_DW_2024.Infrastructure.ILogger;

namespace Hackaton_DW_2024.Data.DataSources.Users;

public class EfUserDataSource : EntityFrameworkDataSource, IUsersDataSource
{
    protected DbSet<UserDto> Users { get; set; }

    public EfUserDataSource(DatabaseConnectionConfig config, ILogger logger) : base(config, logger)
    {
    }

    public UserDto? SelectById(int id) => Users.FirstOrDefault(dto => dto.Id == id);
    public UserDto? SelectByEmail(string email) => Users.FirstOrDefault(dto => dto.Email == email);

    public void InsertOne(UserDto item)
    {
        Users.Add(item);
        SaveChanges();
    }

    public void InsertMany(IEnumerable<UserDto> items)
    {
        Users.AddRange(items);
        SaveChanges();
    }

    public void UpdateById(int id, Action<UserDto> updateFunc)
    {
        var updateTarget = SelectById(id);
        if (updateTarget == null)
        {
            RaiseNotFoundError(UserDto.StructureName,
                new List<KeyValuePair<string, object>>
                {
                    new(nameof(UserDto.Id), id)
                });
            return;
        }

        updateFunc(updateTarget);
        SaveChanges();
    }

    public void DeleteById(int id)
    {
        var deleteTarget = SelectById(id);
        if (deleteTarget == null)
        {
            RaiseNotFoundError(UserDto.StructureName,
                new List<KeyValuePair<string, object>>
                {
                    new(nameof(UserDto.Id), id)
                });
            return;
        }

        Users.Remove(deleteTarget);
        SaveChanges();
    }
}