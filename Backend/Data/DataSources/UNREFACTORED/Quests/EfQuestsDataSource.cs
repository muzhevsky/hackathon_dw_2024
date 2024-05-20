using Hackaton_DW_2024.Data.Dto;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.UNREFACTORED.Quests;

public class EfQuestsDataSource:  IQuestsDataSource
{
    IDbContextFactory<ApplicationContext> _factory;
    public EfQuestsDataSource(IDbContextFactory<ApplicationContext>  context)
    {
        _factory = context;
    }

    public QuestDto? SelectById(int id)
    {
        using var context = _factory.CreateDbContext();
        return context.Quests.FirstOrDefault(dto => dto.Id == id);
    }

    public IEnumerable<QuestDto> SelectByEventId(int eventId)
    {
        using var context = _factory.CreateDbContext();
        return context.Quests.Where(dto => dto.EventId == eventId).ToList();
    }

    public IEnumerable<QuestDto> SelectByTeacherId(int teacherId)
    {
        using var context = _factory.CreateDbContext();
        return context.Quests.Where(dto => dto.TeacherId == teacherId).ToList();
    }

    public IEnumerable<QuestDto> SelectByGroupId(int groupId)
    {
        using var context = _factory.CreateDbContext();
        return context.Quests.Where(dto => dto.GroupId == groupId).ToList();
    }

    public void Insert(QuestDto quest)
    {
        using var context = _factory.CreateDbContext();
        context.Quests.Add(quest);
        context.SaveChanges();
    }
}