using CommandPattern.Core.Contracts;
using CommandPattern.IO.Contracs;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        private readonly IReader reader;
        private readonly IWriter writer;
        private ICommandInterpreter command;



        public Engine(ICommandInterpreter command, IReader reader, IWriter writer)
        {
            this.command = command;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {

            while (true)
            {
                string input = this.reader.ReadLine();
                string result = this.commandInterpreter.Read(input);
                this.writer.WriteLine(result);
            }
        }
    }
}
