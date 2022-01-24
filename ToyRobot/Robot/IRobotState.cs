namespace ToyRobot.Robot
{
    public interface IRobotState
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }
    }
}
