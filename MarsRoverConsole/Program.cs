using System;
using System.Collections.Generic;
using MarsRover;

namespace MarsRoverConsole
{
    /// <summary>
    /// Implementation of the classic Mars Rovers problem.
    /// Sample Specifications: http://www.whereisdeniss.com/applications/mars-rover-c-console-app
    /// </summary>
    class Program
    {
        private const string SampleInput = @"5 5
                                       1 2 N
                                       LMLMLMLMM
                                       3 3 E
                                       MMRMMRMRRM";

        static void Main()
        {
            InputParser inputParser = new InputParser();
            IList<Rover> rovers = new List<Rover>();
            bool validInput;

            // read input
            validInput = inputParser.ReadInput(SampleInput);

            if(!validInput)
            {
                Console.WriteLine("Invalid input data");
                return;
            }

            // establish grid boundary
            IGridBoundary gridBoundary = inputParser.GridBoundary;
            Console.WriteLine(gridBoundary);


            // create and initialize each rover
            foreach (var roverInstruction in inputParser.RoverInstructions)
            {
                Console.WriteLine(roverInstruction.InitialPosition);
                Console.WriteLine(roverInstruction.Command);

                rovers.Add(new Rover(roverInstruction.InitialPosition, roverInstruction.Command, gridBoundary));
            }


            // process each rover and print its final location and orientation
            Console.WriteLine();
            foreach (var rover in rovers)
            {
                rover.Process();
                Console.WriteLine(rover.ToString());
            }


            Console.ReadLine();
        }
    }
}
