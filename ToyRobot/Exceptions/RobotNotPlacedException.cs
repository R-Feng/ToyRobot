using System;

namespace ToyRobot.Exceptions
{
    public class RobotNotPlacedException : Exception
    {
        public RobotNotPlacedException(string message) : base(message)
        {

        }
    }
}
