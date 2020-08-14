using System;
using System.IO;
using Serilog;

namespace FileSplitter.CommandLine
{
    public static class CommandLineOptionsValidator
    {
        public static bool AreValidOptions(this CommandLineOptions options, ILogger logger)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            if (!File.Exists(options.InputFile))
            {
                logger.Error(
                    "Input file {InputFile} does not exist or cannot be accessed",
                    options.InputFile);

                return false;
            }

            if (!Directory.Exists(options.OutputPath))
            {
                logger.Error(
                    "Output location {OutputLocation} does not exist or cannot be accessed",
                    options.OutputPath);

                return false;
            }

            return true;
        }
    }
}
