using System;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MarsRoverTests
{
    /// <summary>
    /// Tests for validating rover actions
    /// </summary>
    [TestClass]
    public class RoverTests
    {
        private Mock<IGridBoundary> boundary;
        private Mock<IInitialPosition> initialPosition;
        private string command;

        private IRover roverOne;
        private IRover roverTwo;
        private IRover delinquentRover;

       
        [TestInitialize]
        public void Setup()
        {
            boundary = new Mock<IGridBoundary>();
            initialPosition = new Mock<IInitialPosition>();
            command = String.Empty;
        }


        public void SetupRoverOne()
        {
            boundary.Setup(b => b).Returns(new GridBoundary(5, 5));
            
            initialPosition.SetupProperty(i => i.X, 1);
            initialPosition.SetupProperty(i => i.Y, 2);
            initialPosition.SetupProperty(i => i.Orientation, Orientations.N);

            command = "LMLMLMLMM";
            
            roverOne = new Rover(initialPosition.Object, command, boundary.Object);
        }


        public void SetupRoverTwo()
        {
            boundary.Setup(b => b).Returns(new GridBoundary(5, 5));

            initialPosition.SetupProperty(i => i.X, 3);
            initialPosition.SetupProperty(i => i.Y, 3);
            initialPosition.SetupProperty(i => i.Orientation, Orientations.E);

            command = "MMRMMRMRRM";

            roverTwo = new Rover(initialPosition.Object, command, boundary.Object);
        }

        
        [TestMethod]
        public void RoverOneShouldBeInCorrectDestination()
        {
            SetupRoverOne();
            roverOne.Process();
            Assert.AreEqual(roverOne.ToString(), "1 3 N");
        }

        
        [TestMethod]
        public void RoverTwoShouldBeInCorrectDestination()
        {
            SetupRoverTwo();
            roverTwo.Process();
            Assert.AreEqual(roverTwo.ToString(), "5 1 E");
        }
    
        
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RoverExceedingBoundaryOriginShouldThrowException()
        {
            // setup a tight boundary
            boundary.Setup(b => b).Returns(new GridBoundary(1, 1));

            initialPosition.SetupProperty(i => i.X, 0);
            initialPosition.SetupProperty(i => i.Y, 0);
            initialPosition.SetupProperty(i => i.Orientation, Orientations.W);

            // move the before the origin
            command = "ML";

            delinquentRover = new Rover(initialPosition.Object, command, boundary.Object);
            delinquentRover.Process();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RoverExceedingBoundaryLimitShouldThrowException()
        {
            // setup a tight boundary
            boundary.Setup(b => b).Returns(new GridBoundary(1, 1));

            initialPosition.SetupProperty(i => i.X, 0);
            initialPosition.SetupProperty(i => i.Y, 0);
            initialPosition.SetupProperty(i => i.Orientation, Orientations.N);

            // move the rover past the grid boundary
            command = "MM";

            delinquentRover = new Rover(initialPosition.Object, command, boundary.Object);
            delinquentRover.Process();
        }

      

    }
}
