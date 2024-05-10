namespace Hackaton_DW_2024.Infrastructure;

public class ConsoleLogger : ILogger
{
    bool _isDevelopment;

    const string DebugPrefix =      "[DEBUG]     |";
    const string WarningPrefix =    "[WARNING]   |";
    const string ErrorPrefix =      "[ERROR]     |";
    const string StackTracePrefix = "[StackTrace]|";
    
    public ConsoleLogger(bool isDevelopment)
    {
        _isDevelopment = isDevelopment;
    }
    
    public void Debug(string message)
    {
        Console.WriteLine(Combine(DebugPrefix, message));
    }

    public void Warn(string message)
    {
        Console.WriteLine(Combine(WarningPrefix, message));
    }

    public void Error(Exception ex)
    {
        Console.WriteLine(Combine(ErrorPrefix, ex.Message));
        if (_isDevelopment)
        {
            Console.WriteLine(Combine(StackTracePrefix, Environment.StackTrace));
        }
    }

    string Combine(string prefix, string message)
    {
        return prefix + " " + message + $". {DateTime.UtcNow}";
    }
}