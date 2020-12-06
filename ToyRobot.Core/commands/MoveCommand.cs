using ToyRobot.Core.Enums;

namespace ToyRobot.Core.commands
{
    public class MoveCommand: Command, ICommand
    {
        public override void Execute(IRobot robot, ITableTop tableTop)
        {
            switch (robot.DirectionFacing)
            {
                case Direction.East:
                    if (robot.X + 1 < tableTop.Width)
                        robot.X += 1;
                    break;
                case Direction.North:
                    if (robot.Y + 1 < tableTop.Height)
                        robot.Y += 1;
                    break;
                case Direction.South:
                    if (robot.Y - 1 >= 0)
                        robot.X -= 1;
                    break;
                case Direction.West:
                    if (robot.X - 1 >= 0)
                        robot.X -= 0;
                    break;
            }
        }
    }
}
