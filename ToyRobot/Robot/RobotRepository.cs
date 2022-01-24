using System;
using Microsoft.Extensions.DependencyInjection;

namespace ToyRobot.Robot
{
    public class RobotRepository : IRobotRepository
    {
        private IRobot _robot;

        public void PlaceRobot(int x, int y, Direction direction)
        {
            _robot = Program.ServiceProvider.GetRequiredService<IRobot>();
            _robot.X = x;
            _robot.Y = y;
            _robot.Direction = direction;
        }

        
        public IRobot GetRobot()
        {
            if (_robot == null)
            {
                throw new RobotNotPlacedException("Robot has not been placed yet.");
            }

            return _robot;
        }
    }
}
