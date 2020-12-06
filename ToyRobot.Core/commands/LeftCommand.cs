using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.Core.Enums;

namespace ToyRobot.Core.commands
{
    public class LeftCommand: Command, ICommand
    {
        public override void Execute(IRobot robot, ITableTop tableTop)
        {
            var index = (int)robot.DirectionFacing;
            index -= 1;
            robot.DirectionFacing = (Direction)(((index % 4) + 4) % 4);
        }
    }
}
