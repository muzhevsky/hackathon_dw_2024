using Hackaton_DW_2024.Data.Dto.Events;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;
using ILogger = Hackaton_DW_2024.Infrastructure.ILogger;

namespace Hackaton_DW_2024.Data.DataSources.News;

public class EfNewsDataSource : EntityFrameworkDataSource, INewsDataSource
{
    DbSet<NewsDto> News { get; set; }
    DbSet<PinnedNewsDto> Pinned { get; set; }

    public EfNewsDataSource(DatabaseConnectionConfig config, ILogger logger) : base(config, logger)
    {
    }

    public NewsDto? SelectById(int id) => News.FirstOrDefault(news => news.Id == id);

    public IEnumerable<NewsDto> SelectAll() => News.ToList();

    public IEnumerable<NewsDto> SelectPinned()
    {
        return News
            .Where(news => Pinned
                .Any(p => p.NewsId == news.Id));
    }

    public IEnumerable<NewsDto> SelectRangeWithOffsetByDate(int range, int offset, bool ascending = true)
    {
        return ascending
            ? News.OrderBy(news => news.PublicationDate).Skip(offset).Take(range)
            : News.OrderByDescending(news => news.PublicationDate).Skip(offset).Take(range);
    }

    public void Insert(NewsDto dto)
    {
        News.Add(dto);
        SaveChanges();
    }

    public void UpdateById(int id, Action<NewsDto> updateFunc)
    {
        var updateTarget = SelectById(id);
        if (updateTarget == null) 
        {
            RaiseNotFoundError(NewsDto.StructureName,
                new List<KeyValuePair<string, object>>
                {
                    new(nameof(NewsDto.Id), id)
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
            RaiseNotFoundError(NewsDto.StructureName,
                new List<KeyValuePair<string, object>>
                {
                    new(nameof(NewsDto.Id), id)
                });
            return;
        }
        News.Remove(deleteTarget);
        SaveChanges();
    }
}