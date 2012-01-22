using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using MarsRover.CommandProcessing;

namespace MarsRover
{
    /// <summary>
    /// Reads a raw input information and parses them into strongly typed instruction objects
    /// </summary>
    public class InputParser
    {
        public IGridBoundary GridBoundary { get; set; }
        public IList<RoverCommand> RoverInstructions { get; set; }

        private static readonly Regex BoundaryLineItemValidRegex = new Regex(@"^\d+\s\d+$");    // validates a boundary line item
        private static readonly Regex InitialCoordinatesValidRegex = new Regex(@"^\d+\s\d+\s[NSWE]$"); // validates an initial coordinate line item
        private static readonly Regex CommandValidRegex  = new Regex(@"^[LRM]+$"); // validates a command line item


        public InputParser()
        {
            RoverInstructions = new List<RoverCommand>();
        }


        /// <summary>
        /// Reads raw input commands and creates a strongly typed object of rover commands
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool ReadInput(string input)
        {

            if (input.Length == 0)
                return false;
            
            using (StringReader reader = new StringReader(input))
            {
                string currentLine;
                IVectorPosition roverInitialPosition = null;
                string roverCommands = String.Empty;
                int lineCounter = 0;
                
                while ((currentLine = reader.ReadLine()) != null)
                {
                    lineCounter++;

                    // cleanup the line of whitespace necessary
                    currentLine = currentLine.Trim();


                    // determine what information the line contains
                    if (BoundaryLineItemValidRegex.Match(currentLine).Success)
                        GridBoundary = ParseBoundary(currentLine); // establish grid boundary
                    else if (InitialCoordinatesValidRegex.Match(currentLine).Success)
                        roverInitialPosition = ParseInitialPosition(currentLine);   // establish initial position
                    else if (CommandValidRegex.Match(currentLine).Success)
                        roverCommands = currentLine; // get rover commands
                    else
                        throw new Exception(String.Format("Line {0} in input contains invalid information", lineCounter));

                    // add the rover to the instruction set if we have sufficient information
                    if (roverInitialPosition != null && !roverCommands.Equals(String.Empty))
                    {
                        RoverInstructions.Add(new RoverCommand(roverInitialPosition, roverCommands));
                        roverInitialPosition = null;
                        roverCommands = String.Empty;
                    }


                }
            }

            return true;
        }


        /// <summary>
        /// Parses boundary string to a coordinate object
        /// </summary>
        /// <param name="boundaryCoordinates"></param>
        /// <returns></returns>
        private GridBoundary ParseBoundary(string boundaryCoordinates)
        {
            String[] coordinates = boundaryCoordinates.Split(' ');
            return new GridBoundary(Int32.Parse(coordinates[0]), Int32.Parse(coordinates[1]));
        }

        /// <summary>
        /// Creates an initial position object from a string
        /// </summary>
        /// <param name="initialPosition"></param>
        /// <returns></returns>
        private VectorPosition ParseInitialPosition(string initialPosition)
        {
            String[] position = initialPosition.Split(' ');

            int initialPositionX = Int32.Parse(position[0]);
            int initialPositionY = Int32.Parse(position[1]);
            Orientations initialOrientation = (Orientations)Enum.Parse(typeof(Orientations), position[2]);

            return new VectorPosition(initialPositionX, initialPositionY, initialOrientation);
        }
    }
}
