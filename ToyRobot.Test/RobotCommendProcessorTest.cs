using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ToyRobot.Robot;

namespace ToyRobot.Test
{
    [TestClass]
    public class RobotCommendProcessorTest
    {
        private Mock<IRobotService> _mockRobotService;

        [TestInitialize]
        public void SetUp()
        {
            _mockRobotService = new Mock<IRobotService>();
        }

        [TestMethod]
        public void WhenProcessPlaceCommendWithRightInputWithDirectionPlaceShouldBeCalled()
        {
            // Arrange
            var robotCommendProcessor = GetRobotCommendProcessor();

            // Act
            robotCommendProcessor.ProcessCommend("PLACE 1,2,EAST");

            // Assert
            _mockRobotService.Verify(mock => mock.Place(1, 2, Direction.EAST), Times.Once);
        }

        [TestMethod]
        public void WhenProcessPlaceCommendWithRightInputWithoutDirectionPlaceShouldBeCalled()
        {
            // Arrange
            var robotCommendProcessor = GetRobotCommendProcessor();

            // Act
            robotCommendProcessor.ProcessCommend("PLACE 3,4");

            // Assert
            _mockRobotService.Verify(mock => mock.Place(3, 4), Times.Once);
        }

        [TestMethod]
        public void WhenProcessPlaceCommendWithWrongInputPlaceShouldNotBeCalled()
        {
            // Arrange
            var robotCommendProcessor = GetRobotCommendProcessor();

            // Act
            robotCommendProcessor.ProcessCommend("PLACE 5");

            // Assert
            _mockRobotService.Verify(mock => mock.Place(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<Direction>()), Times.Never);
            _mockRobotService.Verify(mock => mock.Place(It.IsAny<int>(), It.IsAny<int>()), Times.Never);
        }

        [TestMethod]
        public void WhenProcessMoveCommendMoveShouldBeCalled()
        {
            // Arrange
            var robotCommendProcessor = GetRobotCommendProcessor();

            // Act
            robotCommendProcessor.ProcessCommend("MOVE");

            // Assert
            _mockRobotService.Verify(mock => mock.Move(), Times.Once);
        }

        [TestMethod]
        public void WhenProcessLeftCommendLeftShouldBeCalled()
        {
            // Arrange
            var robotCommendProcessor = GetRobotCommendProcessor();

            // Act
            robotCommendProcessor.ProcessCommend("LEFT");

            // Assert
            _mockRobotService.Verify(mock => mock.Left(), Times.Once);
        }

        [TestMethod]
        public void WhenProcessRightCommendRightShouldBeCalled()
        {
            // Arrange
            var robotCommendProcessor = GetRobotCommendProcessor();

            // Act
            robotCommendProcessor.ProcessCommend("RIGHT");

            // Assert
            _mockRobotService.Verify(mock => mock.Right(), Times.Once);
        }

        [TestMethod]
        public void WhenProcessReportCommendReportShouldBeCalled()
        {
            // Arrange
            var robotCommendProcessor = GetRobotCommendProcessor();

            // Act
            robotCommendProcessor.ProcessCommend("REPORT");

            // Assert
            _mockRobotService.Verify(mock => mock.Report(), Times.Once);
        }

        [TestMethod]
        public void WhenProcessWrongCommendNoMethodShouldBeCalled()
        {
            // Arrange
            var robotCommendProcessor = GetRobotCommendProcessor();

            // Act
            robotCommendProcessor.ProcessCommend("WRONG COMMEND");

            // Assert
            _mockRobotService.Verify(mock => mock.Place(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<Direction>()), Times.Never);
            _mockRobotService.Verify(mock => mock.Place(It.IsAny<int>(), It.IsAny<int>()), Times.Never);
            _mockRobotService.Verify(mock => mock.Move(), Times.Never);
            _mockRobotService.Verify(mock => mock.Left(), Times.Never);
            _mockRobotService.Verify(mock => mock.Right(), Times.Never);
            _mockRobotService.Verify(mock => mock.Report(), Times.Never);
        }

        private RobotCommendProcessor GetRobotCommendProcessor()
        {
            var robotCommendProcessor = new RobotCommendProcessor(_mockRobotService.Object);
            return robotCommendProcessor;
        }
    }
}
