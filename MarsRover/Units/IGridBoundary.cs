namespace MarsRover
{
    /// <summary>
    /// Interface to specify the grid boundary position
    /// </summary>
    public interface IGridBoundary
    {
        Position GridBoundaryPosition { get; }
        string ToString();
    }
}
