using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ToyRobot.Core
{
    public class Simulation
    {
        private ITableTop TableTop { get; }
        private IRobot Robot { get; }

        public Simulation()
        {
            Robot = new Robot();
            TableTop = new TableTop(5,5);
        }

        public void Execute(string commandString)
        {
            var command = CommandFactory.GetCommand(commandString);
            command.Execute(Robot,TableTop);
        }
    }
}
