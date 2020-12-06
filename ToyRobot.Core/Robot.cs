using ToyRobot.Core.Enums;
    

namespace ToyRobot.Core
{
    public class Robot : IRobot
    {

        public int X { get; set; }
        public int Y { get; set; }
        public Direction DirectionFacing { get; set; }

        public Robot()
        {
            X = -1;
            Y = -1;
        }
    }
}
