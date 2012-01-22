using System;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests
{
    /// <summary>
    /// Tests for reading and handling command inputs
    /// </summary>
    [TestClass]
    public class CommandProcessorTests
    {

        private const string SampleValidInput = @"5 5
                                                 1 2 N
                                                 LMLMLMLMM
                                                 3 3 E
                                                 MMRMMRMRRM";

        private IInputParser inputParser;

        [TestInitialize]
        public void SetupProcessor()
        {
            inputParser = new InputParser();
        }

        private void SetupProcessorWithValidInput()
        {
            inputParser.ReadInput(SampleValidInput);
        }

        [TestMethod]
        public void CommandProcessorShouldGetValidInput()
        {
            SetupProcessorWithValidInput();
            Assert.IsTrue(inputParser.ReadInput(SampleValidInput));
        }


        [TestMethod]
        public void CommandProcessorShouldGetCorrectNumberOfRovers()
        {
            SetupProcessorWithValidInput();
            Assert.AreEqual(inputParser.RoverInstructions.Count, 2);   
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CommandProcessorShouldHandleInvalidBoundaryItem()
        {
             const string invalidInput = @"5 5 5 <---
                                           1 2 N
                                           LMLMLMLMM
                                           3 3 E
                                           MMRMMRMRRM";
            try
            {
                inputParser.ReadInput(invalidInput);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Line 1 in input contains invalid information", ex.Message);
                throw;
            }
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CommandProcessorShouldHandleInvalidInitialCoordinateItem()
        {
            const string invalidInput =     @"5 5
                                            1 2 N <----
                                            LMLMLMLMM";
            try
            {
                inputParser.ReadInput(invalidInput);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Line 2 in input contains invalid information", ex.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CommandProcessorShouldHandleInvalidCommandItem()
        {
            const string invalidInput = @"5 5
                                            1 2 N
                                            LMLMLMLMMZ<----";
            try
            {
                inputParser.ReadInput(invalidInput);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Line 3 in input contains invalid information", ex.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CommandProcessorShouldHandleMissingLines()
        {
            const string invalidInput = @"5 5 5
                                          1 2 N";
            inputParser.ReadInput(invalidInput);
        }


    }
}
