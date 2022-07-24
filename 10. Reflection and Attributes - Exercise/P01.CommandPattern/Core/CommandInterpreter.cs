using CommandPattern.Common;
using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] cmndSplit = args.Split(' ');
            string cmndName = cmndSplit[0];
            string[] ccmndArgs = cmndSplit.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();
            Type cmngType = assembly.GetTypes().FirstOrDefault(t => t.Name == $"{cmndName}Command" && t.GetInterfaces().Any(i => i == typeof(ICommand)));

            if (cmngType == null)
            {
                throw new InvalidOperationException(String.Format(ErrorMessages.InvalidCommandType, $"{cmndName}Command"));

            }
            object cmndInstance = Activator.CreateInstance(cmngType);
            MethodInfo executeMethod = cmngType.GetMethods().First(m => m.Name == "Execute");
            string result = (string)executeMethod.Invoke(cmndInstance, new object[] { ccmndArgs });
            return result;
        }
    }
}
