namespace ToyRobot.Robot
{
    public interface IRobotService
    {
        public void Place(int x, int y, Direction direction);
        public void Place(int x, int y);
        public void Move();
        public void Left();
        public void Right();
        public string Report();
    }
}
