namespace MarsRover
{
    /// <summary>
    /// A vector contains a position value and direction
    /// </summary>
    public class VectorPosition : IVectorPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Orientations Orientation { get; set; }

        public VectorPosition(int x, int y, Orientations orientation)
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
