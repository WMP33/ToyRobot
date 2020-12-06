using System;
using NUnit.Framework;
using ToyRobot.Core;
using ToyRobot.Core.commands;
using Moq;
using ToyRobot.Core.Enums;

namespace ToyRobot.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LeftCommand()
        {
            var mockTable = Mock.Of<ITableTop>();
            var robot = new Robot() { X = 2, Y = 2, DirectionFacing = Direction.South };
            var command = new LeftCommand();
            command.Execute(robot, mockTable);
            Assert.AreEqual(robot.DirectionFacing, Direction.East);
        }

        public void MoveNorthCommand()
        {
            var table = new TableTop(5, 5);
            var robot = new Robot() { X = 2, Y = 2, DirectionFacing = Direction.North };
            var command = new MoveCommand();
            command.Execute(robot, table);
            Assert.AreEqual(robot.Y, 3);
        }

        public void MoveEastCommand()
        {
            var table = new TableTop(5, 5);
            var robot = new Robot() { X = 2, Y = 2, DirectionFacing = Direction.East };
            var command = new MoveCommand();
            command.Execute(robot, table);
            Assert.AreEqual(robot.X, 3);
        }
        public void MoveSouthCommand()
        {
            var table = new TableTop(5, 5);
            var robot = new Robot() { X = 2, Y = 2, DirectionFacing = Direction.South };
            var command = new MoveCommand();
            command.Execute(robot, table);
            Assert.AreEqual(robot.Y, 1);
        }

        public void MoveWestCommand()
        {
            var table = new TableTop(5, 5);
            var robot = new Robot() { X = 2, Y = 2, DirectionFacing = Direction.West };
            var command = new MoveCommand();
            command.Execute(robot, table);
            Assert.AreEqual(robot.X, 1);
        }

        [Test]
        public void LeftCommandWrap()
        {
            var mockTable = Mock.Of<ITableTop>();
            var robot = new Robot() { X = 0, Y = 0, DirectionFacing = Direction.North };
            var command = new LeftCommand();
            command.Execute(robot, mockTable);
            Assert.AreEqual(robot.DirectionFacing, Direction.West);
        }

        [Test]
        public void RightCommand()
        {
            var mockTable = Mock.Of<ITableTop>();
            var robot = new Robot() { X = 0, Y = 0, DirectionFacing = Direction.North };
            var command = new RightCommand();
            command.Execute(robot, mockTable);
            Assert.AreEqual(robot.DirectionFacing, Direction.East);
        }

        [Test]
        public void RightCommandWrap()
        {
            var mockTable = Mock.Of<ITableTop>();
            var robot = new Robot() { X = 0, Y = 0, DirectionFacing = Direction.West };
            var command = new RightCommand();
            command.Execute(robot, mockTable);
            Assert.AreEqual(robot.DirectionFacing, Direction.North);
        }

        [Test]
        public void PlaceRobotInvalidX()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var placeCommand = new PlaceCommand("PLACE a,1,North");
            });
        }

        [Test]
        public void PlaceRobotInvalidY()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var placeCommand = new PlaceCommand("PLACE 1,b,North");
            });
        }

        [Test]
        public void PlaceRobotInvalidDirection()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var placeCommand = new PlaceCommand("PLACE 1,1,Nth");
            });
        }

        [Test]
        public void PlaceRobot()
        {
            var placeCommand = new PlaceCommand("2,4,south");
            var table = new TableTop(5, 5);
            var robot = new Robot();
            placeCommand.Execute(robot, table);
            Assert.AreEqual(2,robot.X);
            Assert.AreEqual(4, robot.Y);
            Assert.AreEqual(Direction.South, robot.DirectionFacing);
        }

        [Test]
        [TestCase("Left")]
        [TestCase("Right")]
        [TestCase("Move")]
        [TestCase("Report")]
        [TestCase("Place 1,1,North")]
        public void CommandFactoryTest(string commandString)
        {
            var command = CommandFactory.GetCommand(commandString);
            switch (commandString)
            {
                case "Left":
                    Assert.IsInstanceOf( typeof(LeftCommand), command);
                    break;
                case "Right":
                    Assert.IsInstanceOf( typeof(RightCommand), command);
                    break;
                case "Move":
                    Assert.IsInstanceOf( typeof(MoveCommand), command);
                    break;
                case "Report":
                    Assert.IsInstanceOf( typeof(ReportCommand), command);
                    break;
                case "Place 1,1,North":
                    Assert.IsInstanceOf( typeof(PlaceCommand), command);
                    break;
                default:
                    Assert.Fail("TestCase not Implemented");
                    break;
            }
        }
    }
}
