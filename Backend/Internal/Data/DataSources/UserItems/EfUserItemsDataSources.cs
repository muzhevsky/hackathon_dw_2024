﻿using Hackaton_DW_2024.Internal.Data.Config;
using Hackaton_DW_2024.Internal.Data.Dto.Customization;
using Hackaton_DW_2024.Internal.Data.Package;
using Microsoft.EntityFrameworkCore;
using ILogger = Hackaton_DW_2024.Infrastructure.Logging.ILogger;

namespace Hackaton_DW_2024.Internal.Data.DataSources.UserItems;

public class EfUserItemsDataSources : EntityFrameworkDataSource, IUserItemsDataSource
{
    protected DbSet<UserItemsDto> UserItems { get; set; }

    public EfUserItemsDataSources(DatabaseConnectionConfig config, ILogger logger) : base(config, logger)
    {
    }

    public IEnumerable<UserItemsDto> SelectByUserId(int userId) => UserItems.Where(dto => dto.UserId == userId);

    public void InsertOne(UserItemsDto dto)
    {
        UserItems.Add(dto);
        SaveChanges();
    }

    public void InsertMany(IEnumerable<UserItemsDto> dtos)
    {
        UserItems.AddRange(dtos);
        SaveChanges();
    }
}