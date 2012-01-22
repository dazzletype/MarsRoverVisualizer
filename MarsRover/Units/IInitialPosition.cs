namespace MarsRover
{
    /// <summary>
    /// Strongly typed initial position object
    /// </summary>
    public interface IInitialPosition
    {
        IPosition Position { get; set; }
        Orientations Orientation { get; set; }
    }


}
