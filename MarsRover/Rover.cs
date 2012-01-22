using System;
using System.Collections.Generic;

namespace MarsRover
{
    /// <summary>
    /// Sends commands to the Rover for moving and orienting positions.
    /// </summary>
    public class Rover : IRover
    {
        public IPosition RoverPosition { get; set; }
        public IVectorPosition RoverInitialPosition { get; set; }
        public Orientations RoverOrientation { get; set; }
        public IGridBoundary GridBoundary { get; set; }
        public IList<IVectorPosition> MovementHistory { get; set; }
        public string Command { get; set; }


        /// <summary>
        /// Create a new rover and set its instructions
        /// </summary>
        /// <param name="initialPosition">Rover's initial position</param>
        /// <param name="command">Rover's movement commands</param>
        /// <param name="gridBoundary">Position to limit of rover's movement to</param>
        public Rover(IVectorPosition initialPosition, string command, IGridBoundary gridBoundary)
        {
            Command = command; 
            RoverInitialPosition = initialPosition;
            RoverPosition = initialPosition;
            RoverOrientation = initialPosition.Orientation;
            GridBoundary = gridBoundary;
            MovementHistory = new List<IVectorPosition>();
        }

        /// <summary>
        /// Processes string of commants to turn or move the Rover
        /// </summary>
        public void Process()
        {
            foreach (var command in Command)
            {
                switch (command)
                {
                    case ('L'):
                        TurnLeft();
                        break;
                    case ('R'):
                        TurnRight();
                        break;
                    case ('M'):
                        Move();
                        break;
                    default:
                        throw new ArgumentException(string.Format("Invalid value: {0}", command));
                }

                MovementHistory.Add(new VectorPosition(RoverPosition.X, RoverPosition.Y, RoverOrientation));
            }
        }

        /// <summary>
        /// Check if Rover is within the boundaries
        /// </summary>
        /// <returns><code>true</code> if Rover is within boundaries</returns>
        public bool IsRobotInsideBoundaries
        {
            get
            {
                bool isInsideBoundaries = RoverPosition.X > GridBoundary.X || RoverPosition.Y > GridBoundary.Y;
                return isInsideBoundaries;
            }
        }

        /// <summary>
        /// Rotate the Rover Left
        /// </summary>
        private void TurnLeft()
        {
            RoverOrientation = (RoverOrientation - 1) < Orientations.N ? Orientations.W : RoverOrientation - 1;
        }

        /// <summary>
        /// Rotate the Rover Right
        /// </summary>
        private void TurnRight()
        {
            RoverOrientation = (RoverOrientation + 1) > Orientations.W ? Orientations.N : RoverOrientation + 1;
        }


        /// <summary>
        /// Move the Rover
        /// </summary>
        private void Move()
        {
            if (RoverOrientation == Orientations.N)
                RoverPosition.Y++;
            else if (RoverOrientation == Orientations.E)
                RoverPosition.X++;
            else if (RoverOrientation == Orientations.S)
                RoverPosition.Y--;
            else if (RoverOrientation == Orientations.W)
                RoverPosition.X--;

            if(RoverPosition.X > GridBoundary.X || RoverPosition.Y > GridBoundary.Y)
                throw new IndexOutOfRangeException("Rover has gone past the boundaries and into space");

            if (RoverPosition.X < 0 || RoverPosition.Y < 0)
                throw new IndexOutOfRangeException("Rover has gone past the boundaries into the negative world");
        }


        /// <summary>
        /// Print out the rover position
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string printedRoverPosition = string.Format("{0} {1} {2}", RoverPosition.X, RoverPosition.Y, RoverOrientation.GetStringValue());
            
            if (IsRobotInsideBoundaries)
                printedRoverPosition = string.Format("Rover outside the boundary, Rover position: {0} , boundary limit {1}", printedRoverPosition, GridBoundary);

            return printedRoverPosition;
        }
      
    }
}
