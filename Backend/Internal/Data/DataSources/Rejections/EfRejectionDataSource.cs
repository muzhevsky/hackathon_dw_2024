using Hackaton_DW_2024.Internal.Data.Config;
using Hackaton_DW_2024.Internal.Data.Dto.Achievements;
using Hackaton_DW_2024.Internal.Data.Package;
using Microsoft.EntityFrameworkCore;
using ILogger = Hackaton_DW_2024.Infrastructure.Logging.ILogger;

namespace Hackaton_DW_2024.Internal.Data.DataSources.Rejections;

public class EfRejectionDataSource: EntityFrameworkDataSource, IRejectionsDataSource
{
    DbSet<RejectionDto> Rejections;
    public EfRejectionDataSource(DatabaseConnectionConfig config, ILogger logger) : base(config, logger)
    {
    }

    public RejectionDto? SelectById(int id) => Rejections.FirstOrDefault(dto => dto.Id == id);

    public IEnumerable<RejectionDto> SelectByRequestId(int requestId) =>
        Rejections.Where(dto => dto.RequestId == requestId);

    public void Insert(RejectionDto dto)
    {
        Rejections.Add(dto);
        SaveChanges();
    }
}