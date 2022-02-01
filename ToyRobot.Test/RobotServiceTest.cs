using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Exceptions;
using ToyRobot.Robot;

namespace ToyRobot.Test
{
    [TestClass]
    public class RobotServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(RobotNotPlacedException))]
        public void RobotMustBePlacedBeforeMoveOtherwiseThrowRobotNotPlacedException()
        {
            // Arrange
            var robotService = GetRobotService();

            // Act
            robotService.Move();

            // Assert - Expects RobotNotPlacedException
            // This is not dead code. Assert is done by [ExpectedException] attribute above method signature.
        }

        [TestMethod]
        [ExpectedException(typeof(RobotNotPlacedException))]
        public void RobotMustBePlacedBeforeLeftOtherwiseThrowRobotNotPlacedException()
        {
            // Arrange
            var robotService = GetRobotService();

            // Act
            robotService.Left();

            // Assert - Expects RobotNotPlacedException
            // This is not dead code. Assert is done by [ExpectedException] attribute above method signature.
        }

        [TestMethod]
        [ExpectedException(typeof(RobotNotPlacedException))]
        public void RobotMustBePlacedBeforeRightOtherwiseThrowRobotNotPlacedException()
        {
            // Arrange
            var robotService = GetRobotService();

            // Act
            robotService.Right();

            // Assert - Expects RobotNotPlacedException
            // This is not dead code. Assert is done by [ExpectedException] attribute above method signature.
        }

        [TestMethod]
        [ExpectedException(typeof(RobotNotPlacedException))]
        public void RobotMustBePlacedBeforeReportOtherwiseThrowRobotNotPlacedException()
        {
            // Arrange
            var robotService = GetRobotService();

            // Act
            robotService.Report();

            // Assert - Expects RobotNotPlacedException
            // This is not dead code. Assert is done by [ExpectedException] attribute above method signature.
        }

        [TestMethod]
        public void RobotMustBeMovedToTheRightPositionWhenPlacedNorth()
        {
            // Arrange
            var robotService = GetRobotService();

            // Act
            robotService.Place(0,0,Direction.NORTH);
            robotService.Move();

            // Assert
            Assert.AreEqual("0,1,NORTH", robotService.Report());
        }

        [TestMethod]
        public void RobotMustBeFacingTheRightDirectionWhenMovedLeft()
        {
            // Arrange
            var robotService = GetRobotService();

            // Act
            robotService.Place(0, 0, Direction.NORTH);
            robotService.Left();

            // Assert
            Assert.AreEqual("0,0,WEST", robotService.Report());
        }

        [TestMethod]
        public void RobotMustBeMovedToTheRightPositionAfterMultipleMoves()
        {
            // Arrange
            var robotService = GetRobotService();

            // Act
            robotService.Place(1, 2, Direction.EAST);
            robotService.Move();
            robotService.Move();
            robotService.Left();
            robotService.Move();

            // Assert
            Assert.AreEqual("3,3,NORTH", robotService.Report());
        }

        [TestMethod]
        public void RobotMustBeMovedToTheRightPositionAfterBeingPlacedAgain()
        {
            // Arrange
            var robotService = GetRobotService();

            // Act
            robotService.Place(1, 2, Direction.EAST);
            robotService.Move();
            robotService.Left();
            robotService.Move();
            robotService.Place(3, 1);
            robotService.Move();

            // Assert
            Assert.AreEqual("3,2,NORTH", robotService.Report());
        }

        [TestMethod]
        [ExpectedException(typeof(RobotOutBoundaryException))]
        public void RobotCannotBePlacedOutOfBoundaryOtherwiseThrowRobotOutBoundaryException()
        {
            // Arrange
            var robotService = GetRobotService();

            // Act
            robotService.Place(1, 8, Direction.EAST);

            // Assert - Expects RobotOutBoundaryException
            // This is not dead code. Assert is done by [ExpectedException] attribute above method signature.
        }

        [TestMethod]
        [ExpectedException(typeof(RobotOutBoundaryException))]
        public void RobotCannotBeMovedOutOfBoundaryOtherwiseThrowRobotOutBoundaryException()
        {
            // Arrange
            var robotService = GetRobotService();

            // Act
            robotService.Place(6, 6, Direction.EAST);
            robotService.Move();

            // Assert - Expects RobotOutBoundaryException
            // This is not dead code. Assert is done by [ExpectedException] attribute above method signature.
        }

        private static IRobotService GetRobotService()
        {
            return new RobotService(new RobotRepository());
        }
    }
}
