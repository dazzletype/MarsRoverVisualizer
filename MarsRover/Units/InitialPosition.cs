namespace MarsRover
{
    /// <summary>
    /// Strongly typed object to represent the initial position of rover (coordinates and orientation)
    /// </summary>
    public class InitialPosition : IInitialPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Orientations Orientation { get; set; }

        public InitialPosition(int x, int y, Orientations orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;
        }

        /// <summary>
        /// Prints out the initial position as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", X, Y, Orientation);
        }
    }
}
