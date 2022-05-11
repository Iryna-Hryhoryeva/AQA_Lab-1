using NLog;

namespace Waits_Alerts_WindowsHandling.Utils;

public class Log
{
    private static Logger _logger = LogManager.GetCurrentClassLogger();

    public static void Info(string message)
    {
        _logger.Info(message);
    }
}
