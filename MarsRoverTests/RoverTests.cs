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
        private string command;
        private Rover delinquentRover;
        private Mock<IVectorPosition> initialPosition;

        private Rover roverOne;
        private Rover roverTwo;

        [TestInitialize]
        public void Setup()
        {
            boundary = new Mock<IGridBoundary>();
            initialPosition = new Mock<IVectorPosition>();
            command = String.Empty;
        }


        /// <summary>
        /// Set up a rover with the instructions per the first example of the sample input:
        /// 1 2 N
        /// LMLMLMLM
        /// </summary>
        public void SetupRoverOne()
        {
            boundary.SetupProperty(i => i.X, 5);
            boundary.SetupProperty(i => i.Y, 5);

            initialPosition.SetupProperty(i => i.X, 1);
            initialPosition.SetupProperty(i => i.Y, 2);
            initialPosition.SetupProperty(i => i.Orientation, Orientations.N);

            command = "LMLMLMLMM";

            roverOne = new Rover(initialPosition.Object, command, boundary.Object);
        }


        /// <summary>
        /// Set up a rover with the instructions per the second example of the sample input:
        /// 3 3 E
        /// MMRMMRMRRM
        /// </summary>
        public void SetupRoverTwo()
        {
            boundary.SetupProperty(i => i.X, 5);
            boundary.SetupProperty(i => i.Y, 5);

            initialPosition.SetupProperty(i => i.X, 3);
            initialPosition.SetupProperty(i => i.Y, 3);
            initialPosition.SetupProperty(i => i.Orientation, Orientations.E);

            command = "MMRMMRMRRM";

            roverTwo = new Rover(initialPosition.Object, command, boundary.Object);
        }

        /// <summary>
        /// Test if rover one's final position matches the example output
        /// </summary>
        [TestMethod]
        public void RoverOneShouldBeInCorrectDestination()
        {
            SetupRoverOne();
            roverOne.Process();
            Assert.AreEqual(roverOne.ToString(), "1 3 N");
        }


        /// <summary>
        /// Test if rover two's final position matches the example output
        /// </summary>
        [TestMethod]
        public void RoverTwoShouldBeInCorrectDestination()
        {
            SetupRoverTwo();
            roverTwo.Process();
            Assert.AreEqual(roverTwo.ToString(), "5 1 E");
        }


        /// <summary>
        /// Test if Rover responds properly to moving before the origin point by moving it before the origin
        /// --------------
        /// |      |     |  
        /// --------------
        /// |W(0,0)|     |  
        /// --------------
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (IndexOutOfRangeException))]
        public void RoverExceedingBoundaryOriginShouldThrowException()
        {
            // setup a tight boundary
            boundary.SetupProperty(i => i.X, 1);
            boundary.SetupProperty(i => i.Y, 1);

            initialPosition.SetupProperty(i => i.X, 0);
            initialPosition.SetupProperty(i => i.Y, 0);
            initialPosition.SetupProperty(i => i.Orientation, Orientations.W);

            // move the before the origin
            command = "M";

            delinquentRover = new Rover(initialPosition.Object, command, boundary.Object);
            delinquentRover.Process();
        }

        /// <summary>
        /// Test if Rover responds properly to moving past the boundary point by moving it past the boundary
        /// ---------------
        /// |      |N(0,0)|  
        /// ---------------
        /// |      |      |
        /// ---------------
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (IndexOutOfRangeException))]
        public void RoverExceedingBoundaryLimitShouldThrowException()
        {
            // setup a tight boundary
            boundary.SetupProperty(i => i.X, 1);
            boundary.SetupProperty(i => i.Y, 1);

            initialPosition.SetupProperty(i => i.X, 1);
            initialPosition.SetupProperty(i => i.Y, 1);
            initialPosition.SetupProperty(i => i.Orientation, Orientations.N);

            // move the rover past the grid boundary
            command = "M";

            delinquentRover = new Rover(initialPosition.Object, command, boundary.Object);
            delinquentRover.Process();
        }
    }
}