using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.Core.commands
{
    public interface ICommand
    {
        void Execute(IRobot robot, ITableTop tableTop);
    }
}
