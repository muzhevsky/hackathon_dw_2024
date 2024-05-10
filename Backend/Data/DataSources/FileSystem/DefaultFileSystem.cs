using Hackaton_DW_2024.Data.Dto.Achievements;

namespace Hackaton_DW_2024.Data.DataSources.FileSystem;

public class DefaultFileSystem : IFileSystem
{
    public void Write(FileDto file)
    {
        File.WriteAllBytes(file.Name, file.Content);
    }

    public FileDto Read(string fileName)
    {
        var content = File.ReadAllBytes(fileName);
        return new FileDto
        {
            Name = fileName,
            Content = content
        };
    }
}