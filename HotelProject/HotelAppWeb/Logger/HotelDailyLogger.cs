namespace HotelAppWeb.Logger;
public class HotelDailyLogger : ILogger
{
    private readonly string _logFilePath;
    private DateTime _lastLogDate;
    private readonly object _lock = new object();

    public HotelDailyLogger(string logFilePath)
    {
        _logFilePath = logFilePath;

        try
        {
            _lastLogDate = File.GetLastWriteTime(_logFilePath).Date;
        }
        catch 
        {
            _lastLogDate = DateTime.Now.Date;
        }
    }

    public IDisposable BeginScope<TState>(TState state) => null;

    public bool IsEnabled(LogLevel logLevel) => true; // Or implement your log level logic

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        if (!IsEnabled(logLevel))
        {
            return;
        }

        var message = formatter(state, exception);
        WriteLog(message);
    }

    private void WriteLog(string message)
    {
        lock (_lock)
        {
            try
            {
                DateTime currentDate = DateTime.Now.Date;
                if (currentDate > _lastLogDate)
                {
                    _lastLogDate = currentDate;
                    File.WriteAllText(_logFilePath, ""); // Overwrite the file
                }

                string logEntry = $"{DateTime.Now}: {message}\n";
                File.AppendAllText(_logFilePath, logEntry);
            }
            catch (Exception ex)
            {
                try
                {
                    File.AppendAllText("fallback-log.txt", $"{DateTime.Now}: Failed to log to main file. Error: {ex.Message}\n");
                }
                catch
                {
                    //ignore the error
                }
            }
            
        }
    }
}
