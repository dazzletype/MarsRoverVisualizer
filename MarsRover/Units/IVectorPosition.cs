namespace MarsRover
{
    /// <summary>
    /// Vector position of Rover, including position and heading
    /// </summary>
    public interface IVectorPosition : IPosition
    {
        Orientations Orientation { get; set; }
    }
}
