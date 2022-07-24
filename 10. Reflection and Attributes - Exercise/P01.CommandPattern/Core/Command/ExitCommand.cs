using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern.Core.Command
{
    public class ExitCommand : ICommand
    {
        private const int SuccessExitCode = 0;
        public string Execute(string[] args)
        {
            Environment.Exit(SuccessExitCode);
            return null;
        }
    }
}
