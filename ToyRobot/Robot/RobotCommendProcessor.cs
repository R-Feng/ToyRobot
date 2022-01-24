using System;
using System.Linq;

namespace ToyRobot.Robot
{
    public class RobotCommendProcessor : IRobotCommendProcessor
    {
        private readonly IRobotService _robotService;

        public RobotCommendProcessor(IRobotService robotService)
        {
            _robotService = robotService;
        }

        public void ProcessCommend(string commend, ref bool running)
        {
            if (commend.StartsWith("PLACE", StringComparison.CurrentCultureIgnoreCase))
            {
                ProcessPlaceCommend(commend);
            }
            else if (commend.StartsWith("MOVE", StringComparison.CurrentCultureIgnoreCase))
            {
                ProcessMoveCommend();
            }
            else if (commend.StartsWith("LEFT", StringComparison.CurrentCultureIgnoreCase))
            {
                ProcessLeftCommend();
            }
            else if (commend.StartsWith("RIGHT", StringComparison.CurrentCultureIgnoreCase))
            {
                ProcessRightCommend();
            }
            else if (commend.StartsWith("REPORT", StringComparison.CurrentCultureIgnoreCase))
            {
                ProcessReportCommend(out running);
            }
            else
            {
                Console.WriteLine("Wrong commend. Only PLACE, MOVE, LEFT, RIGHT and REPORT are supported.");
            }
        }

        private void ProcessPlaceCommend(string commend)
        {
            var commendParameters = commend.Split(' ').Where(c => !string.IsNullOrWhiteSpace(c))
                .Select(c => c.Trim()).ToArray();
            if (commendParameters.Length != 2)
            {
                Console.WriteLine("Wrong commend parameter. Only PLACE X, Y, DIRECTION is supported.");
                return;
            }

            var robotParameters = commendParameters[1].Split(',').Where(c => !string.IsNullOrWhiteSpace(c))
                .Select(c => c.Trim()).ToArray();
            if (robotParameters.Length == 2)
            {
                _robotService.Place(Convert.ToInt32(robotParameters[0]), Convert.ToInt32(robotParameters[1]));
            }
            else if (robotParameters.Length == 3)
            {
                _robotService.Place(Convert.ToInt32(robotParameters[0]), Convert.ToInt32(robotParameters[1]),
                    Enum.Parse<Direction>(robotParameters[2], true));
            }
            else
            {
                Console.WriteLine("Wrong robot parameter. Only PLACE X, Y, DIRECTION is supported.");
            }
        }

        private void ProcessMoveCommend()
        {
            _robotService.Move();
        }

        private void ProcessLeftCommend()
        {
            _robotService.Left();
        }

        private void ProcessRightCommend()
        {
            _robotService.Right();
        }

        private void ProcessReportCommend(out bool running)
        {
            Console.WriteLine(_robotService.Report());
            Console.WriteLine("Please press <Enter> to continue, please any other key to exit.");
            running = Console.ReadKey().Key == ConsoleKey.Enter;
        }
    }
}
