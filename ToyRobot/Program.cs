using System;
using System.IO;
using ToyRobot.Core;

namespace ToyRobot
{
    public class Program
    {
        public static void Main()
        {
            ConsoleKeyInfo cki;
            do
            {
                Console.WriteLine("1. Press 1 to enter commands for the Robot.");
                Console.WriteLine("2. Press 2 to enter a file with commands for the Robot.");
                Console.WriteLine("3. Press escape to exit");
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.D1)
                {
                    SimulateRobotWithCommands();
                }
                else if (cki.Key == ConsoleKey.D2)
                {
                    SimulateRobotWithFileEntry();
                }
            } while (cki.Key != ConsoleKey.Escape);
        }

        private static void SimulateRobotWithFileEntry()
        {
            var filePath = "";
            var simulation = new Simulation();
            Console.Clear();
            Console.WriteLine(@"1. Enter the location of the file with commands. (c:\temp\commandfile.txt)");
            Console.WriteLine("EXIT");
            do
            {
                filePath = Console.ReadLine();
                try
                {
                    if (filePath != null && File.Exists(filePath))
                    {
                        foreach (var line in File.ReadLines(filePath))
                        {
                            try
                            {
                                simulation.Execute(line);
                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine("command ignored. {0}", e.Message);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("command ignored.");
                }

            } while (filePath != null && filePath.ToLower() != "exit");
        }

        private static void SimulateRobotWithCommands()
        {
            var command = "";
            var simulation = new Simulation();
            Console.Clear();
            Console.WriteLine("1. Valid commands are");
            Console.WriteLine("PLACE X, Y, F");
            Console.WriteLine("MOVE ");
            Console.WriteLine("LEFT");
            Console.WriteLine("RIGHT");
            Console.WriteLine("REPORT");
            Console.WriteLine("EXIT");
            do
            {

                command = Console.ReadLine();
                try
                {
                    if (command != null && command.ToLower() != "exit")
                        simulation.Execute(command);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("command ignored. {0}",e.Message);
                }

            } while (command != null && command.ToLower() != "exit");
        }
    }
}
