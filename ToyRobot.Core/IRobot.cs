using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.Core.Enums;

namespace ToyRobot.Core
{
    public interface IRobot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction DirectionFacing { get; set; }
    }
}
