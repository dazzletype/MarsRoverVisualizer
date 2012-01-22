namespace MarsRover
{
    /// <summary>
    /// A history item of a rover movement
    /// </summary>
    public interface IMovementHistoryItem
    {
        int X { get; set; }
        int Y { get; set; }
        string Orientation { get; set; }
    }
}
