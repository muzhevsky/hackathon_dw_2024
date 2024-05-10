using Hackaton_DW_2024.Data.Dto.Events;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.News;

public class EfNewsDataSource : EntityFrameworkDataSource, INewsDataSource
{
    DbSet<NewsDto> News { get; set; }
    DbSet<PinnedNewsDto> Pinned { get; set; }

    public EfNewsDataSource(DatabaseConnectionConfig config) : base(config)
    {
    }

    public NewsDto? SelectById(int id) => News.FirstOrDefault(news => news.Id == id);

    public IEnumerable<NewsDto> SelectAll() => News.ToList();

    public IEnumerable<NewsDto> SelectPinned()
    {
        return News
            .Where(news => Pinned
                .Any(p => p.NewsId == news.Id))
            .ToList();
    }

    public IEnumerable<NewsDto> SelectRangeWithOffsetByDate(int range, int offset, bool ascending = true)
    {
        return ascending
            ? News.OrderBy(news => news.PublicationDate).Skip(offset).Take(range).ToList()
            : News.OrderByDescending(news => news.PublicationDate).Skip(offset).Take(range).ToList();
    }

    public void Insert(NewsDto dto)
    {
        News.Add(dto);
        SaveChanges();
    }

    public void UpdateById(int id, Action<NewsDto> updateFunc)
    {
        var updateTarget = SelectById(id);
        if (updateTarget == null) throw new Exception("no entity found");
        updateFunc(updateTarget);
        SaveChanges();
    }

    public void DeleteById(int id)
    {
        var deleteTarget = SelectById(id);
        if (deleteTarget == null) throw new Exception("no entity found");
        News.Remove(deleteTarget);
        SaveChanges();
    }
}