using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.Core
{
    public interface ISimulation
    {
        public void Execute(string command);
    }
}
