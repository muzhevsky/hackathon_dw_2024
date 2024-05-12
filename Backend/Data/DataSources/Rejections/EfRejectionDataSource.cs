using Hackaton_DW_2024.Data.Config;
using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Rejections;

public class EfRejectionDataSource: EntityFrameworkDataSource, IRejectionsDataSource
{
    DbSet<RejectionDto> Rejections { get; set; }
    public EfRejectionDataSource(ApplicationContext context) : base(context)
    {
        Rejections = context.Rejections;
    }

    public RejectionDto? SelectById(int id) => Rejections.FirstOrDefault(dto => dto.Id == id);

    public IEnumerable<RejectionDto> SelectByRequestId(int requestId) =>
        Rejections.Where(dto => dto.RequestId == requestId);

    public void Insert(RejectionDto dto)
    {
        Rejections.Add(dto);
        Context.SaveChanges();
    }
}