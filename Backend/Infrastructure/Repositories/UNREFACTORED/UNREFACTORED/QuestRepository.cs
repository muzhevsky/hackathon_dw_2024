namespace Hackaton_DW_2024.Infrastructure.Repositories.UNREFACTORED;

public class QuestRepository
{
    // IQuestsDataSource _questDataSource;
    // ITeacherDataSource _teacherDataSource;
    //
    // public QuestRepository(IQuestsDataSource questDataSource, ITeacherDataSource teacherDataSource)
    // {
    //     _questDataSource = questDataSource;
    //     _teacherDataSource = teacherDataSource;
    // }
    //
    // public QuestDto GetById(int id) => _questDataSource.SelectById(id);
    // public List<QuestDto> GetByTeacherId(int teacherId) => _questDataSource.SelectByTeacherId(teacherId).ToList();
    // public List<QuestDto> GetByEventId(int eventId) => _questDataSource.SelectByEventId(eventId).ToList();
    // public List<QuestDto> GetByGroupId(int groupId) => _questDataSource.SelectByGroupId(groupId).ToList();
    //
    // public QuestDto Create(CreateQuestRequest request, int userId)
    // {
    //     var teacher = _teacherDataSource.SelectByUserId(userId);
    //     if (teacher == null) 
    //         throw new AuthException("unauthorized");
    //     var dto = new QuestDto
    //     {
    //         Description = request.Description,
    //         EventId = request.EventId,
    //         GroupId = request.GroupId,
    //         ResultId = request.ResultId,
    //         TeacherId = teacher.Id
    //     };
    //     _questDataSource.Insert(dto);
    //     return dto;
    // }
}