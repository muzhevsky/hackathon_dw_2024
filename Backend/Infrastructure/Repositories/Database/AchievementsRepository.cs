using Hackaton_DW_2024.Api.Student;
using Hackaton_DW_2024.Data.DataSources.Achievements;
using Hackaton_DW_2024.Data.DataSources.EventsAndAchievements;
using Hackaton_DW_2024.Data.DataSources.FileSystem;
using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Internal.Converters;
using Hackaton_DW_2024.Internal.Entities;
using Hackaton_DW_2024.Internal.Entities.Users;

namespace Hackaton_DW_2024.Infrastructure.Repositories.Database;

public class AchievementsRepository
{
    IConverter<Achievement, AchievementDto> _converter;
    IAchievementsDataSource _achievementsDataSource;
    ICustomAchievementDataSource _customAchievementDataSource;
    IAchievementsAndEventsDataSource _achievementsAndEventsDataSource;
    IFileSystem _fileSystem;
    const string PathString = "/app/achievements";

    public AchievementsRepository(
        IAchievementsDataSource achievementsDataSource,
        IFileSystem fileSystem, 
        IConverter<Achievement, AchievementDto> converter, 
        IAchievementsAndEventsDataSource achievementsAndEventsDataSource)
    {
        _achievementsDataSource = achievementsDataSource;
        _fileSystem = fileSystem;
        _converter = converter;
        _achievementsAndEventsDataSource = achievementsAndEventsDataSource;

        Directory.CreateDirectory(PathString);
    }

    public Achievement? GetById(int id)
    {
        return _converter.ConvertBack(_achievementsDataSource.SelectById(id));
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
        _achievementsAndEventsDataSource.Insert(new AchievementsAndEventsDto
        {
            AchievementId = achievement.Id,
            EventId = eventId
        });
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
        
    }
}