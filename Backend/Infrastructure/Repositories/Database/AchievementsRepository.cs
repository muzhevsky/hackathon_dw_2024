using Hackaton_DW_2024.Api.Student;
using Hackaton_DW_2024.Data.DataSources.Achievements;
using Hackaton_DW_2024.Data.DataSources.Events;
using Hackaton_DW_2024.Data.DataSources.Events.Results;
using Hackaton_DW_2024.Data.DataSources.Events.Statuses;
using Hackaton_DW_2024.Data.DataSources.FileSystem;
using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Internal.Converters;
using Hackaton_DW_2024.Internal.Entities;
using Hackaton_DW_2024.Internal.Entities.Users;

namespace Hackaton_DW_2024.Infrastructure.Repositories.Database;

public class AchievementsRepository
{
    IConverter<Achievement, AchievementDto> _converter;
    IEventsDataSource _eventsDataSource;
    IAchievementsDataSource _achievementsDataSource;
    ICustomAchievementDataSource _customAchievementDataSource;
    IEventResultsDataSource _eventResultsDataSource;
    IEventStatusesDataSource _eventStatusesDataSource;
    IFileSystem _fileSystem;
    const string PathString = "/app/achievements";

    public AchievementsRepository(
        IAchievementsDataSource achievementsDataSource,
        IFileSystem fileSystem, 
        IConverter<Achievement, AchievementDto> converter, 
        ICustomAchievementDataSource customAchievementDataSource, 
        IEventsDataSource eventsDataSource, 
        IEventResultsDataSource eventResultsDataSource, 
        IEventStatusesDataSource eventStatusesDataSource)
    {
        _achievementsDataSource = achievementsDataSource;
        _fileSystem = fileSystem;
        _converter = converter;
        _customAchievementDataSource = customAchievementDataSource;
        _eventsDataSource = eventsDataSource;
        _eventResultsDataSource = eventResultsDataSource;
        _eventStatusesDataSource = eventStatusesDataSource;

        Directory.CreateDirectory(PathString);
    }

    public Achievement? GetById(int id)
    {
        return _converter.ConvertBack(_achievementsDataSource.SelectById(id));
    }

    public AchievementForRequest? GetAchievementForRequestById(int id)
    {
        var achievement = _achievementsDataSource.SelectById(id);
        var title = "";
        var date = "";
        var status = "";
        var result = _eventResultsDataSource.SelectById(achievement.ResultId);
        if (achievement.EventId == null)
        {
            var custom = _customAchievementDataSource.SelectByAchievementId(id);
            title = custom.Title;
            date = custom.Date;
            status = _eventStatusesDataSource.SelectById(id).Title;
        }
        else
        {
            var ev = _eventsDataSource.SelectById(achievement.EventId.Value);
            title = ev.Title;
            date = ev.StartDate.ToUniversalTime().ToString();
            status = _eventStatusesDataSource.SelectById(ev.StatusId).Title;
        }

        var achievementForRequest = new AchievementForRequest
        {
            TeamStatus = achievement.WithTeam ? "Командное" : "Личное",
            Title = title,
            Date = date,
            Result = result.Title,
            Status = status
        };

        return achievementForRequest;
    }
    
    public List<Achievement> AchievementsOfStudent(Student student)
    {
        var result = new List<Achievement>();
        foreach (var achievement in _achievementsDataSource.SelectByUserId(student.UserId))
        {
            result.Add(_converter.ConvertBack(achievement));
        }

        return result;
    }

    public void AddAchievement(Achievement achievement, Stream fileStream)
    {
        var split = achievement.FilePath.Split('.');
        var count = split.Length;
        var extension = split[count - 1];
        var id = _achievementsDataSource.Insert(_converter.Convert(achievement));
        var fileName = id + "." + extension;
        var path = PathString + fileName;
        _fileSystem.Write(new FileDto
        {
            Stream = fileStream,
            Path = path
        });
        _achievementsDataSource.UpdateById(id, dto => dto.FilePath = path);
        achievement.Id = id;
        achievement.FilePath = path;
    }

    public void AttachToEvent(Achievement achievement, int eventId)
    {
        _achievementsDataSource.UpdateById(achievement.Id, dto => dto.EventId = eventId);
        if (_customAchievementDataSource.SelectByAchievementId(achievement.Id) != null)
        {
            _customAchievementDataSource.RemoveById(achievement.Id);
        }
    }
    
    public void UpdateAchievement(Achievement achievement)
    {
        _achievementsDataSource.UpdateById(achievement.Id, dto =>
        {
            dto.WithTeam = achievement.WithTeam;
            dto.ResultId = achievement.ResultId;
        });
    }

    public void AddCustom(Achievement achievement, AddCustomAchievementRequest request)
    {
        _achievementsDataSource.UpdateById(achievement.Id,
            dto =>
            {
                dto.EventId = null;
                dto.ResultId = request.ResultId;
                dto.WithTeam = request.WithTeam;
            });
        _customAchievementDataSource.Insert(new CustomAchievementDto
        {
            AchievementId = achievement.Id,
            Date = request.Date,
            Title = request.Title,
            StatusId  = request.StatusId
        });
    }
}