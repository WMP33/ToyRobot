using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.Core.commands
{
    public class ReportCommand: Command, ICommand
    {
        public override void Execute(IRobot robot, ITableTop tableTop)
        {
            Console.WriteLine("{0},{1},{2}", robot.X, robot.Y, robot.DirectionFacing);
        }
    }
}
