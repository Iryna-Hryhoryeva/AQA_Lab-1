using NLog;

namespace TASK_6.Utils;

public class Log
{
    private static Logger _logger = LogManager.GetCurrentClassLogger();

    public static void Info(string message)
    {
        _logger.Info(message);
    }
    
    public static void Debug(string message)
    {
        _logger.Debug(message);
    }
    
    public static void Warn(string message)
    {
        _logger.Warn(message);
    }
}
