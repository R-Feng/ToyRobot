using System;

namespace ToyRobot.Exceptions
{
    public class RobotOutBoundaryException : Exception
    {
        public RobotOutBoundaryException(string message) : base(message)
        {

        }
    }
}
