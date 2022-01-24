namespace ToyRobot.Robot
{
    public interface IRobotCommendProcessor
    {
        public void ProcessCommend(string commend, ref bool running);
    }
}
