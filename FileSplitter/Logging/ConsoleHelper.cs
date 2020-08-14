using System;

namespace FileSplitter.Logging
{
    public static class ConsoleHelper
    {
        public static void DisplayDebugMessage()
        {
#if DEBUG
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
#endif
        }
    }
}
