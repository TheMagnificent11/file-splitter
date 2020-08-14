using CommandLine;

namespace FileSplitter.CommandLine
{
    public static class CommandLineParser
    {
        public static CommandLineOptions ParseCommandLineArgs(this string[] args)
        {
            var options = new CommandLineOptions();
            var hasCommandLineErrors = false;

            Parser.Default.ParseArguments<CommandLineOptions>(args)
                .WithParsed(x =>
                {
                    options.InputFile = x.InputFile;
                    options.LinesPerFile = x.LinesPerFile;
                    options.OutputPath = x.OutputPath;
                })
                .WithNotParsed(_ => hasCommandLineErrors = true);

            if (hasCommandLineErrors)
            {
                return null;
            }

            return options;
        }
    }
}
