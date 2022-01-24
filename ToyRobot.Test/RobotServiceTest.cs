using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Exceptions;
using ToyRobot.Robot;

namespace ToyRobot.Test
{
    [TestClass]
    public class RobotServiceTest
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            Program.RegisterServices();
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            Program.DisposeServices();
        }

        [TestMethod]
        [ExpectedException(typeof(RobotNotPlacedException))]
        public void RobotMustBePlacedBeforeMove()
        {
            // Arrange
            var robotService = GetRobotService();

            // Act
            robotService.Move();

            // Assert - Expects RobotNotPlacedException
        }

        [TestMethod]
        [ExpectedException(typeof(RobotNotPlacedException))]
        public void RobotMustBePlacedBeforeLeft()
        {
            // Arrange
            var robotService = GetRobotService();

            // Act
            robotService.Left();

            // Assert - Expects RobotNotPlacedException
        }

        [TestMethod]
        [ExpectedException(typeof(RobotNotPlacedException))]
        public void RobotMustBePlacedBeforeRight()
        {
            // Arrange
            var robotService = GetRobotService();

            // Act
            robotService.Right();

            // Assert - Expects RobotNotPlacedException
        }

        [TestMethod]
        [ExpectedException(typeof(RobotNotPlacedException))]
        public void RobotMustBePlacedBeforeReport()
        {
            // Arrange
            var robotService = GetRobotService();

            // Act
            robotService.Report();

            // Assert - Expects RobotNotPlacedException
        }

        [TestMethod]
        public void TestCaseExample1()
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
        public void TestCaseExample2()
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
        public void TestCaseExample3()
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
        public void TestCaseExample4()
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

        private static IRobotService GetRobotService()
        {
            return Program.ServiceProvider.GetRequiredService<IRobotService>();
        }
    }
}
