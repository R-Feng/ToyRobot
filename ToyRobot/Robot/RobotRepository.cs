using Microsoft.Extensions.DependencyInjection;
using ToyRobot.Exceptions;

namespace ToyRobot.Robot
{
    public class RobotRepository : IRobotRepository
    {
        private IRobotState _robot;

        public void PlaceRobot(int x, int y, Direction direction)
        {
            _robot = Program.ServiceProvider.GetRequiredService<IRobotState>();
            _robot.X = x;
            _robot.Y = y;
            _robot.Direction = direction;
        }

        
        public IRobotState GetRobot()
        {
            if (_robot == null)
            {
                throw new RobotNotPlacedException("Robot has not been placed yet.");
            }

            return _robot;
        }
    }
}
