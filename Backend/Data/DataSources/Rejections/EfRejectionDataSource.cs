using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Rejections;

public class EfRejectionDataSource:  IRejectionsDataSource
{
    IDbContextFactory<ApplicationContext> _factory;
    public EfRejectionDataSource(IDbContextFactory<ApplicationContext>  context)
    {
        _factory = context;
    }

    public RejectionDto? SelectById(int id)
    {
        using var context = _factory.CreateDbContext();
        return context.Rejections.FirstOrDefault(dto => dto.Id == id);
    }

    public IEnumerable<RejectionDto> SelectByRequestId(int requestId)
    {
        using var context = _factory.CreateDbContext();
        return context.Rejections.Where(dto => dto.RequestId == requestId);
    }

    public void Insert(RejectionDto dto)
    {
        using var context = _factory.CreateDbContext();
        context.Rejections.Add(dto);
        context.SaveChanges();
    }
}