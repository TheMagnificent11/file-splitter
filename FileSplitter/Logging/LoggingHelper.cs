using Serilog;
using Serilog.Events;

namespace FileSplitter.Logging
{
    public static class LoggingHelper
    {
        public static ILogger CreateConsoleAppLogger()
        {
            return new LoggerConfiguration()
                .WriteTo.Console(LogEventLevel.Information)
                .CreateLogger();
        }
    }
}
