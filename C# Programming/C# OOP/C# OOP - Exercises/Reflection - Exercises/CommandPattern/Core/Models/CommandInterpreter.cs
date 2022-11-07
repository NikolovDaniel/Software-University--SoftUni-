using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] tokens = args.Split();

            string commandName = tokens[0];
            string[] arr = tokens[1..];

            Type cmd = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == $"{commandName}Command");

            ICommand command = (ICommand)Activator.CreateInstance(cmd);

            string result = command.Execute(arr);

            return result;
        }
    }
}
