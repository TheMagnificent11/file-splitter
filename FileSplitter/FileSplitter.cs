using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FileSplitter.CommandLine;
using Serilog;

namespace FileSplitter
{
    public class FileSplitter
    {
        private readonly CommandLineOptions options;
        private readonly ILogger logger;

        public FileSplitter(CommandLineOptions options, ILogger logger)
        {
            this.options = options;
            this.logger = logger.ForContext<FileSplitter>();
        }

        public async Task Split()
        {
            var fileName = Path.GetFileNameWithoutExtension(this.options.InputFile);
            var fileExtension = Path.GetExtension(this.options.InputFile);
            var lines = File.ReadLines(this.options.InputFile).Count();

            this.logger.Information("Total Lines: {TotalLines}", lines);
            Console.WriteLine();

            using (var lineIterator = File.ReadLines(this.options.InputFile).GetEnumerator())
            {
                var stillGoing = true;

                for (var chunk = 1; stillGoing; chunk++)
                {
                    stillGoing = await this.WriteChunk(lineIterator, chunk, fileName, fileExtension);
                }
            }
        }

        private async Task<bool> WriteChunk(
            IEnumerator<string> lineIterator,
            int chunk,
            string fileNamePrefix,
            string extension)
        {
            var filePath = Path.Combine(this.options.OutputPath, $"{fileNamePrefix}-{chunk:000}{extension}");

            using (var writer = File.CreateText(filePath))
            {
                for (var i = 0; i < this.options.LinesPerFile; i++)
                {
                    if (!lineIterator.MoveNext())
                    {
                        writer.Close();
                        return false;
                    }

                    await writer.WriteLineAsync(lineIterator.Current);
                }

                writer.Close();
            }

            this.logger.Information("File Created: {FileName}", filePath);

            return true;
        }
    }
}
