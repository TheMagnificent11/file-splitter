using CommandLine;

namespace FileSplitter.CommandLine
{
    public class CommandLineOptions
    {
        [Option('i', Required = true, HelpText = "Full file path (including file name and extension) to file to be split")]
        public string InputFile { get; set; }

        [Option('o', Required = true, HelpText = "Location for output files")]
        public string OutputPath { get; set; }

        [Option('n', Required = true, HelpText = "The maximum number of lines for each smaller file")]
        public int LinesPerFile { get; set; }
    }
}
