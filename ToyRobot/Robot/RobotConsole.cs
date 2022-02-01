using System;

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
            while (true)
            {
                Console.Write(">");
                var commend = Console.ReadLine();
                if (commend == null)
                {
                    continue;
                }

                try
                {
                    _robotCommendProcessor.ProcessCommend(commend);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
