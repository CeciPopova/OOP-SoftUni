using CommandPattern.IO.Contracs;
using System;

namespace CommandPattern.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
