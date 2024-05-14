using Hackaton_DW_2024.Data.Dto;
using Hackaton_DW_2024.Data.Package;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.DataSources.Quests;

public class EfQuestsDataSource: EntityFrameworkDataSource, IQuestsDataSource
{
    DbSet<QuestDto> _quests;
    public EfQuestsDataSource(ApplicationContext context) : base(context)
    {
        _quests = context.Quests;
    }

    public QuestDto? SelectById(int id)
    {
        return _quests.FirstOrDefault(dto => dto.Id == id);
    }

    public IEnumerable<QuestDto> SelectByEventId(int eventId)
    {
        return _quests.Where(dto => dto.EventId == eventId);
    }

    public IEnumerable<QuestDto> SelectByGroupId(int groupId)
    {
        return _quests.Where(dto => dto.GroupId == groupId);
    }

    public void Insert(QuestDto quest)
    {
        _quests.Add(quest);
        Context.SaveChanges();
    }
}