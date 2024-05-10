namespace Hackaton_DW_2024.Infrastructure;

public interface ILogger
{
    void Debug(string message);
    void Warn(string message);
    void Error(Exception ex);
}