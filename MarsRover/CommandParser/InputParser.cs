﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using MarsRover.CommandProcessing;

namespace MarsRover
{
    /// <summary>
    /// Reads raw input information and parses them into a Boundary and Rover command objects
    /// Object consists of:
    /// [D D]                   Grid Boundary, common to all rovers
    /// ([D D [NSWE])([LRM*])   Rover's initial position, Rover's movement commands
    /// ([D D [NSWE])([LRM*])
    /// ([D D [NSWE])([LRM*])
    /// etc.
    /// </summary>
    public class InputParser
    {
        private static readonly Regex BoundaryLineItemValidRegex = new Regex(@"^\d+\s\d+$"); // validates a boundary line item
        private static readonly Regex InitialCoordinatesRowValidRegex = new Regex(@"^\d+\s\d+\s[NSWE]$"); // validates an initial coordinate line item
        private static readonly Regex CommandRowValidRegex = new Regex(@"^[LRM]+$"); // validates a command line item


        public InputParser()
        {
            RoverInstructions = new List<RoverCommand>();
        }

        public IGridBoundary GridBoundary { get; set; }
        public IList<RoverCommand> RoverInstructions { get; set; }


        /// <summary>
        /// Reads raw input commands and creates a strongly typed object of rover commands
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool ReadInput(string input)
        {
            if (input.Length == 0)
                return false;

            using (var reader = new StringReader(input))
            {
                string currentLine;
                IVectorPosition roverInitialPosition = null;
                string roverCommands = String.Empty;
                int lineCounter = 0;

                while ((currentLine = reader.ReadLine()) != null)
                {
                    lineCounter++;

                    // cleanup the line of whitespace from input if necessary
                    currentLine = currentLine.Trim();

                    // create strongly typed instruction objects based on raw data format of the current line
                    if (BoundaryLineItemValidRegex.Match(currentLine).Success)
                        GridBoundary = ParseBoundary(currentLine); // establish grid boundary
                    else if (InitialCoordinatesRowValidRegex.Match(currentLine).Success)
                        roverInitialPosition = ParseInitialPosition(currentLine); // establish initial position
                    else if (CommandRowValidRegex.Match(currentLine).Success)
                        roverCommands = currentLine; // get rover commands
                    else
                        throw new Exception(String.Format("Line {0} in input contains invalid information", lineCounter));

                    // add the rover to the instruction set if we have sufficient information
                    if (roverInitialPosition != null && !roverCommands.Equals(String.Empty) && GridBoundary != null)
                    {
                        RoverInstructions.Add(new RoverCommand(roverInitialPosition, roverCommands));
                        roverInitialPosition = null;
                        roverCommands = String.Empty;
                    }
                }

                // need at least a valid grid boundary
                if (GridBoundary == null)
                    throw new Exception("Grid boundary not defined (should be first line in input)");

                // need enough instructions to process at least one rover
                if (RoverInstructions.Count == 0)
                    throw new Exception("No complete instructions exist to process at least one rover");
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
            var initialOrientation = (Orientations) Enum.Parse(typeof (Orientations), position[2]);

            return new VectorPosition(initialPositionX, initialPositionY, initialOrientation);
        }
    }
}