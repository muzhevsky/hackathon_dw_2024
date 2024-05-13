namespace Hackaton_DW_2024.Internal.Entities;

public class File
{
    public File(byte[] content)
    {
        Content = content;
    }

    public byte[] Content { get; set; }
}