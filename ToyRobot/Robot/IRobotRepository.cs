namespace ToyRobot.Robot
{
    public interface IRobotRepository
    {
        public void PlaceRobot(int x, int y, Direction direction);
        public IRobotState GetRobot();
    }
}
