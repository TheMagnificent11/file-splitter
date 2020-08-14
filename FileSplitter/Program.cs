using System;
using System.Threading.Tasks;
using FileSplitter.CommandLine;
using FileSplitter.Logging;

namespace FileSplitter
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var options = args.ParseCommandLineArgs();

            if (options == null)
            {
                Environment.Exit(-1);
                ConsoleHelper.DisplayDebugMessage();
                return;
            }

            var logger = LoggingHelper.CreateConsoleAppLogger();

            if (!options.AreValidOptions(logger))
            {
                Environment.Exit(-1);
                ConsoleHelper.DisplayDebugMessage();
                return;
            }

            var fileSplitter = new FileSplitter(options, logger);

            await fileSplitter.Split();

            ConsoleHelper.DisplayDebugMessage();
        }
    }
}
