using Hackaton_DW_2024.Data.Dto;

namespace Hackaton_DW_2024.Data.DataSources.Quests;

public interface IQuestsDataSource
{
    QuestDto? SelectById(int id);
    IEnumerable<QuestDto> SelectByEventId(int eventId);
    IEnumerable<QuestDto> SelectByGroupId(int groupId);
    void Insert(QuestDto quest);
}