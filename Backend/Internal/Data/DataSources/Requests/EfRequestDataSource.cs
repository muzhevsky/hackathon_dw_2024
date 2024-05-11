using Hackaton_DW_2024.Internal.Data.Config;
using Hackaton_DW_2024.Internal.Data.Dto.Achievements;
using Hackaton_DW_2024.Internal.Data.Package;
using Microsoft.EntityFrameworkCore;
using ILogger = Hackaton_DW_2024.Infrastructure.Logging.ILogger;

namespace Hackaton_DW_2024.Internal.Data.DataSources.Requests;

public class EfRequestDataSource : EntityFrameworkDataSource, IRequestDataSource
{
    DbSet<RequestDto> Requests;

    public EfRequestDataSource(DatabaseConnectionConfig config, ILogger logger) : base(config, logger)
    {
    }

    public RequestDto? SelectById(int id) => Requests.FirstOrDefault(dto => dto.Id == id);

    public IEnumerable<RequestDto> SelectByUserId(int userId) => Requests.Where(dto => dto.UserId == userId);

    public void Insert(RequestDto dto)
    {
        Requests.Add(dto);
        SaveChanges();
    }

    public void UpdateById(int id, Action<RequestDto> updateFunc)
    {
        var updateTarget = Requests.First(dto => dto.Id == id);
        if (updateTarget == null)
        {
            RaiseNotFoundError(RequestDto.StructureName,
                new List<KeyValuePair<string, object>>
                {
                    new(nameof(RequestDto.Id), id)
                });
            return;
        }

        updateFunc(updateTarget);
        SaveChanges();
    }

    public void DeleteById(int id)
    {
        var deleteTarget = Requests.FirstOrDefault(dto => dto.Id == id);
        if (deleteTarget == null)
        {
            RaiseNotFoundError(RequestDto.StructureName,
                new List<KeyValuePair<string, object>>
                {
                    new(nameof(RequestDto.Id), id)
                });
            return;
        }

        Requests.Remove(deleteTarget);
        SaveChanges();
    }
}