namespace MarsRover
{
    /// <summary>
    /// Initial position of Rover plus orientation
    /// </summary>
    public interface IInitialPosition : IPosition
    {
        Orientations Orientation { get; set; }
    }
}
