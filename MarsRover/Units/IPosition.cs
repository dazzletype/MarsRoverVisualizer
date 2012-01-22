namespace MarsRover
{
    /// <summary>
    /// Interface of a position unit. This interface should be used as a base class to be inherited by other units that utilize this structure.
    /// </summary>
    public interface IPosition
    {
        int X { get; set; }
        int Y { get; set; }
        string ToString();
    }
}
