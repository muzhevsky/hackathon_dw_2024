using Hackaton_DW_2024.Data.Dto.Achievements;

namespace Hackaton_DW_2024.Data.DataSources.FileSystem;

public class DefaultFileSystem : IFileSystem
{
    readonly IWebHostEnvironment _webHostEnvironment;

    public DefaultFileSystem(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public void Write(FileDto file)
    {
        using (var fileStream = new FileStream(_webHostEnvironment.WebRootPath + "/" + file.Path, FileMode.Create))
        {
            file.Stream.CopyTo(fileStream);
        }
    }

    public FileDto Read(string path, string name)
    {
        var content = File.Open(path + "/" + name, FileMode.Open);
        return new FileDto
        {
            Path = path,
            Stream = content
        };
    }
}