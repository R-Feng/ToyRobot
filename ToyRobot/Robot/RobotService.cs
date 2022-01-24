namespace ToyRobot.Robot
{
    public class RobotService : IRobotService
    {
        private readonly IRobotRepository _robotRepository;

        public RobotService(IRobotRepository robotRepository)
        {
            _robotRepository = robotRepository;
        }

        public void Place(int x, int y, Direction direction)
        {
            _robotRepository.PlaceRobot(x, y, direction);
        }

        public void Place(int x, int y)
        {
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
                    robot.Y++;
                    break;
                case Direction.SOUTH:
                    robot.Y--;
                    break;
                case Direction.EAST:
                    robot.X++;
                    break;
                case Direction.WEST:
                    robot.X--;
                    break;
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
