namespace MarsRover
{
    /// <summary>
    /// Interface to set the position of the Rover
    /// </summary>
    public interface IPosition
    {
        int X { get; set; }
        int Y { get; set; }
        string ToString();
    }
}
