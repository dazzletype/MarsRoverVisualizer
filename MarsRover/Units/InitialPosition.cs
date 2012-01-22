namespace MarsRover
{
    /// <summary>
    /// Strongly typed object to represent the initial position of rover (coordinates and orientation)
    /// </summary>
    public class InitialPosition : IInitialPosition
    {
        public IPosition Position { get; set; }
        public Orientations Orientation { get; set; }

        public InitialPosition(Position position, Orientations orientation)
        {
            Position = position;
            Orientation = orientation;
        }

        /// <summary>
        /// Prints out the initial position as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Position.X, Position.Y, Orientation);
        }
    }
}
