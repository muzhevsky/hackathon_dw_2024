using Hackaton_DW_2024.Data.Dto.Events;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.News;

public class EfNewsDataSource :  INewsDataSource
{
    IDbContextFactory<ApplicationContext> _factory;
    public EfNewsDataSource(IDbContextFactory<ApplicationContext>  context)
    {
        _factory = context;
    }

    public NewsDto? SelectById(int id)
    {
        using var context = _factory.CreateDbContext();
        return context.News.FirstOrDefault(news => news.Id == id);
    }

    public IEnumerable<NewsDto> SelectAll()
    {
        using var context = _factory.CreateDbContext();
        return context.News.ToList();
    }

    public IEnumerable<NewsDto> SelectRangeWithOffsetByDate(int range, int offset, bool ascending = true)
    {
        using var context = _factory.CreateDbContext();
        return ascending
            ? context.News.OrderBy(news => news.PublicationDate).Skip(offset).Take(range)
            : context.News.OrderByDescending(news => news.PublicationDate).Skip(offset).Take(range);
    }

    public void Insert(NewsDto dto)
    {
        using var context = _factory.CreateDbContext();
        context.News.Add(dto);
        context.SaveChanges();
    }

    public void UpdateById(int id, Action<NewsDto> updateFunc)
    {
        using var context = _factory.CreateDbContext();
        var updateTarget = SelectById(id);
        updateFunc(updateTarget);
        context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        using var context = _factory.CreateDbContext();
        var deleteTarget = SelectById(id);
        context.News.Remove(deleteTarget);
        context.SaveChanges();
    }
}