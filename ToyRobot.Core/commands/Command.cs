using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.Core
{
    public abstract class Command
    {
        public abstract void Execute(IRobot robot, ITableTop tableTop);
    }
}
