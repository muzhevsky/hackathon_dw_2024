using Hackaton_DW_2024.Api.Teacher;
using Hackaton_DW_2024.Data.DataSources.Groups;
using Hackaton_DW_2024.Data.DataSources.Quests;
using Hackaton_DW_2024.Data.Dto;

namespace Hackaton_DW_2024.Infrastructure.Repositories.Database;

public class QuestRepository
{
    IQuestsDataSource _questDataSource;

    public QuestRepository(IQuestsDataSource questDataSource)
    {
        _questDataSource = questDataSource;
    }

    public QuestDto GetById(int id) => _questDataSource.SelectById(id);
    public List<QuestDto> GetByEventId(int eventId) => _questDataSource.SelectByEventId(eventId).ToList();
    public List<QuestDto> GetByGroupId(int groupId) => _questDataSource.SelectByEventId(groupId).ToList();

    public void Create(CreateQuestRequest request, int userId)
    {
        _questDataSource.Insert(new QuestDto
        {
            Description = request.Desctiption,
            EventId = request.EventId,
            GroupId = request.GroupId,
            ResultId = request.ResultId,
            TeacherId = userId
        });
    }
}