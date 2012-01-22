namespace MarsRover
{
    /// <summary>
    /// Initial position of Rover plus orientation
    /// </summary>
    public interface IVectorPosition : IPosition
    {
        Orientations Orientation { get; set; }
    }
}
