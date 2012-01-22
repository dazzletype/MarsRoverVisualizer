namespace MarsRover
{
    /// <summary>
    /// Establishes the plateau/grid size by providing a boundary coordinate originating from the lower left corner.
    /// For example, a boundary position of 1,2 results in the following grid:
    /// -------------
    /// |     |(1,2)|  
    /// -------------
    /// |     |     |  
    /// -------------
    /// |(0,0)|     |  
    /// -------------
    /// </summary>
    public class GridBoundary : IGridBoundary
    {
        public Position GridBoundaryPosition { get; private set;}

        public GridBoundary(Position position)
        {
            GridBoundaryPosition = position;
        }

        /// <summary>
        /// Prints out the grid boundary as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} {1}", GridBoundaryPosition.X, GridBoundaryPosition.Y);
        }
    }
}
