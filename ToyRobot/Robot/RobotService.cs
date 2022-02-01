using ToyRobot.Exceptions;

namespace ToyRobot.Robot
{
    public class RobotService : IRobotService
    {
        private readonly IRobotRepository _robotRepository;
        private static int xBoundary = 6;
        private static int yBoundary = 6;

        public RobotService(IRobotRepository robotRepository)
        {
            _robotRepository = robotRepository;
        }

        public void Place(int x, int y, Direction direction)
        {
            CheckRobotOutBoundary(x, y);
            _robotRepository.PlaceRobot(x, y, direction);
        }

        public void Place(int x, int y)
        {
            CheckRobotOutBoundary(x, y);
            var robot = _robotRepository.GetRobot();
            robot.X = x;
            robot.Y = y;
        }

        public void Move()
        {
            var robot = _robotRepository.GetRobot();

            switch (robot.Direction)
            {
                case Direction.NORTH:
                    CheckRobotOutBoundary(robot.X, robot.Y + 1);
                    robot.Y++;
                    break;
                case Direction.SOUTH:
                    CheckRobotOutBoundary(robot.X, robot.Y - 1);
                    robot.Y--;
                    break;
                case Direction.EAST:
                    CheckRobotOutBoundary(robot.X + 1, robot.Y);
                    robot.X++;
                    break;
                case Direction.WEST:
                    CheckRobotOutBoundary(robot.X - 1, robot.Y);
                    robot.X--;
                    break;
            }
        }

        private static void CheckRobotOutBoundary(int x, int y)
        {
            if (x > xBoundary || y > yBoundary || x < 0 || y < 0)
            {
                throw new RobotOutBoundaryException($"Operation cancelled due to ({x},{y}) being out of ({xBoundary},{yBoundary}) boundary.");
            }
        }

        public void Left()
        {
            var robot = _robotRepository.GetRobot();

            switch (robot.Direction)
            {
                case Direction.NORTH:
                    robot.Direction = Direction.WEST;
                    break;
                case Direction.SOUTH:
                    robot.Direction = Direction.EAST;
                    break;
                case Direction.EAST:
                    robot.Direction = Direction.NORTH;
                    break;
                case Direction.WEST:
                    robot.Direction = Direction.SOUTH;
                    break;
            }
        }

        public void Right()
        {
            var robot = _robotRepository.GetRobot();

            switch (robot.Direction)
            {
                case Direction.NORTH:
                    robot.Direction = Direction.EAST;
                    break;
                case Direction.SOUTH:
                    robot.Direction = Direction.WEST;
                    break;
                case Direction.EAST:
                    robot.Direction = Direction.SOUTH;
                    break;
                case Direction.WEST:
                    robot.Direction = Direction.NORTH;
                    break;
            }
        }

        public string Report()
        {
            var robot = _robotRepository.GetRobot();

            return $"{robot.X},{robot.Y},{robot.Direction}";
        }
    }
}
