using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.Core.Enums;

namespace ToyRobot.Core.commands
{
    public class PlaceCommand: Command, ICommand
    {
        private readonly int _x;
        private readonly int _y;
        private readonly Direction _directionFacing;
        public PlaceCommand(string parameters)
        {
            var parameterArray = parameters.Split(new char[] { ',' });
            if (parameterArray.Length != 3)
                throw new ArgumentException("Invalid Number of Arguments");

            if (!int.TryParse(parameterArray[0], out _x))
                throw new ArgumentException("Invalid X placement");

            if (!int.TryParse(parameterArray[1], out _y))
                throw new ArgumentException("Invalid Y placement");

            if (!Enum.TryParse(typeof(Direction), parameterArray[2], true, out var direction))
                throw new ArgumentException();
            if (direction != null) _directionFacing = (Direction) direction;
        }
        public override void Execute(IRobot robot, ITableTop tableTop)
        {
            if (_x < 0 || _x >= tableTop.Width || _y < 0 || _y >= tableTop.Height) return;
            robot.X = _x;
            robot.Y = _y;
            robot.DirectionFacing = _directionFacing;
        }  
    }
}
