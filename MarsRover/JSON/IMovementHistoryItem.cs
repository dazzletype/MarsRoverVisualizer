namespace MarsRover
{
    /// <summary>
    /// A history item of a rover movement including positon and heading
    /// </summary>
    public interface IMovementHistoryItem : IPosition
    {
        string Orientation { get; set; }
    }
}
