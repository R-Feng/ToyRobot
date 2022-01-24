using System;
using ToyRobot.Exceptions;

namespace ToyRobot.Robot
{
    public class RobotConsole : IRobotConsole
    {
        private readonly IRobotCommendProcessor _robotCommendProcessor;

        public RobotConsole(IRobotCommendProcessor robotCommendProcessor)
        {
            _robotCommendProcessor = robotCommendProcessor;
        }

        public void Run()
        {
            Console.WriteLine("Welcome to Toy Robot. Please start with your first commend.");
            var running = true;
            do
            {
                Console.Write(">");
                var commend = Console.ReadLine();
                if (commend == null)
                {
                    continue;
                }

                try
                {
                    _robotCommendProcessor.ProcessCommend(commend, ref running);
                }
                catch (RobotNotPlacedException e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (running);
        }
    }
}
