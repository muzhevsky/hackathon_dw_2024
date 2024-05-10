using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Rejections;

public class EfRejectionDataSource: EntityFrameworkDataSource, IRejectionsDataSource
{
    DbSet<RejectionDto> Rejections;
    public EfRejectionDataSource(DatabaseConnectionConfig config) : base(config)
    {
    }

    public RejectionDto? SelectById(int id) => Rejections.FirstOrDefault(dto => dto.Id == id);

    public IEnumerable<RejectionDto> SelectByRequestId(int requestId) =>
        Rejections.Where(dto => dto.RequestId == requestId).ToList();

    public void Insert(RejectionDto dto)
    {
        Rejections.Add(dto);
        SaveChanges();
    }
}