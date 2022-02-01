using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Exceptions;
using ToyRobot.Robot;

namespace ToyRobot.Test
{
    [TestClass]
    public class RobotRepositoryTest
    {
        [TestMethod]
        public void RepositoryShouldReturnCorrectRobotAfterPlacement()
        {
            // Arrange
            var robotRepository = GetRobotRepository();

            // Act
            robotRepository.PlaceRobot(1, 2, Direction.EAST);
            var robot = robotRepository.GetRobot();

            // Assert
            Assert.IsNotNull(robot);
            Assert.AreEqual(robot.X, 1);
            Assert.AreEqual(robot.Y, 2);
            Assert.AreEqual(robot.Direction, Direction.EAST);
        }

        [TestMethod]
        [ExpectedException(typeof(RobotNotPlacedException))]
        public void RobotMustBePlacedBeforeGetRobotOtherwiseThrowRobotNotPlacedException()
        {
            // Arrange
            var robotRepository = GetRobotRepository();

            // Act
            robotRepository.GetRobot();

            // Assert - Expects RobotNotPlacedException
            // This is not dead code. Assert is done by [ExpectedException] attribute above method signature.
        }

        private static IRobotRepository GetRobotRepository()
        {
            return new RobotRepository();
        }
    }
}
