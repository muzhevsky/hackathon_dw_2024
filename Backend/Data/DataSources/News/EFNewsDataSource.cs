using System.Collections;
using Hackaton_DW_2024.Data.Dto;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.News;

public class EFNewsDataSource : EntityFrameworkDataSource, INewsDataSource
{
    DbSet<NewsDto> News { get; set; }
    DbSet<PinnedNewsDto> Pinned { get; set; }
    DbSet<NewsAndEvents> NewsAndEvents { get; set; }

    public EFNewsDataSource(DatabaseConnectionConfig config) : base(config)
    {
    }

    public NewsDto? SelectById(int id)
    {
        return News.FirstOrDefault(news => news.Id == id);
    }

    public List<NewsDto> SelectAll()
    {
        return News.ToList();
    }

    public List<NewsDto> SelectPinned()
    {
        return News
            .Where(news => Pinned
                .Any(p => p.NewsId == news.Id))
            .ToList();
    }

    public List<NewsDto> SelectRangeWithOffsetByDate(int range, int offset, bool ascending = true)
    {
        return ascending
            ? News.OrderBy(news => news.PublicationDate).Skip(offset).Take(range).ToList()
            : News.OrderByDescending(news => news.PublicationDate).Skip(offset).Take(range).ToList();
    }

    public List<NewsDto> SelectByConnectedEvent(int eventId)
    {
        var newsAndEvents = NewsAndEvents.Where(record => record.EventId == eventId).ToList();
        var result = new List<NewsDto>();
        foreach (var record in newsAndEvents)
        {
            result.AddRange(News.Where(dto => dto.Id == record.EventId));
        }

        return result;
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