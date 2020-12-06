using ToyRobot.Core.Enums;
using ToyRobot.Core.commands;
using System;

namespace ToyRobot.Core
{
    public static class CommandFactory
    {
        public static ICommand GetCommand(string commandInput)
        {
            var commandArray =  commandInput.ToUpper().Split(new char[] { ' ' });
            if (!Enum.TryParse(typeof(Commands), commandArray[0], true, out object command))
                throw new ArgumentException("Invalid Command");
            switch ((Commands)command)
            {
                case Commands.Place:
                    if (commandArray.Length != 2)
                        throw new ArgumentException();
                    return new PlaceCommand(commandArray[1]);
                case Commands.Move:
                    return new MoveCommand();
                case Commands.Left:
                    return new LeftCommand();
                case Commands.Right:
                    return new RightCommand();
                case Commands.Report:
                    return new ReportCommand();
                default:
                    throw new ArgumentException("Invalid Command");
            }
        }
    }
}
