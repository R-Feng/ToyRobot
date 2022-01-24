using System;

namespace ToyRobot
{
    public class RobotNotPlacedException : Exception
    {
        public RobotNotPlacedException(string message) : base(message)
        {

        }
    }
}
