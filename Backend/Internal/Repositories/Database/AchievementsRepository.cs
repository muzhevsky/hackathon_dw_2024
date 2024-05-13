using Hackaton_DW_2024.Data.DataSources.Achievements;
using Hackaton_DW_2024.Data.DataSources.FileSystem;
using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Internal.Entities;
using Hackaton_DW_2024.Internal.Entities.Users;

namespace Hackaton_DW_2024.Internal.Repositories.Database;

public class AchievementsRepository
{
    IAchievementsDataSource _achievementsDataSource;
    IFileSystem _fileSystem;
    const string PathString = "/app/achievements";

    public AchievementsRepository(
        IAchievementsDataSource achievementsDataSource,
        IFileSystem fileSystem)
    {
        _achievementsDataSource = achievementsDataSource;
        _fileSystem = fileSystem;

        Directory.CreateDirectory(PathString);
    }

    public List<Achievement> AchievementsOfStudent(Student student)
    {
        var result = new List<Achievement>();
        foreach (var achievement in _achievementsDataSource.SelectByUserId(student.UserId))
        {
            result.Add(new Achievement
            {
                Id = achievement.Id,
                UserId = achievement.UserId,
                TeamSize = achievement.TeamSize,
                FilePath = achievement.FileName
            });
        }

        return result;
    }

    public void AddAchievement(Achievement achievement, Stream fileStream)
    {
        var split = achievement.FilePath.Split('.');
        var count = split.Length;
        var extension = split[count - 1];
        var id = _achievementsDataSource.Insert(
            new AchievementDto
            {
                UserId = achievement.UserId,
                TeamSize = achievement.TeamSize,
                Score = achievement.Score
            });
        var fileName = id + "." + extension;
        var path = PathString + fileName;
        _fileSystem.Write(new FileDto
        {
            Stream = fileStream,
            Path = path
        });
        _achievementsDataSource.UpdateById(id, dto => dto.FileName = path);
        achievement.Id = id;
        achievement.FilePath = path;
    }
}