using System;
using System.Collections.Generic;

namespace MarsRover
{
    /// <summary>
    /// Sends commands to the Rover for moving and orienting positions.
    /// Certain logic inspired by following implementation: http://george2giga.com/2011/02/18/mars-rover-exercise-in-c/
    /// </summary>
    public class Rover
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
                        throw new ArgumentException(string.Format("Error: '{0}' is not a valid rover command", command));
                }
                MovementHistory.Add(new VectorPosition(RoverPosition.X, RoverPosition.Y, (Orientations)Enum.Parse(typeof(Orientations), RoverOrientation.ToString())));
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
            switch (RoverOrientation)
            {
                case Orientations.N:
                    RoverPosition.Y++;
                    break;

                case Orientations.E:
                    RoverPosition.X++;
                    break;

                case Orientations.S:
                    RoverPosition.Y--;
                    break;
                    
                case Orientations.W:
                    RoverPosition.X--;
                    break;
            }

            if(RoverPosition.X > GridBoundary.X || RoverPosition.Y > GridBoundary.Y)
                throw new IndexOutOfRangeException("Error: Rover has gone past the boundaries and into space");

            if (RoverPosition.X < 0 || RoverPosition.Y < 0)
                throw new IndexOutOfRangeException("Error: Rover has gone past the boundaries into the negative world");
        }


        /// <summary>
        /// Print out the rover's final position
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", RoverPosition.X, RoverPosition.Y, RoverOrientation.GetStringValue());
        }
      
    }
}
