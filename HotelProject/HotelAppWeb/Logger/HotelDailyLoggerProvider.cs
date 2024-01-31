namespace HotelAppWeb.Logger
{
    public class HotelDailyLoggerProvider : ILoggerProvider
    {
        private readonly string _logFilePath;

        public HotelDailyLoggerProvider(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new HotelDailyLogger(_logFilePath);
        }

        public void Dispose() { }
    }
}
