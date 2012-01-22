namespace MarsRover
{
    public interface IRover
    {
        IPosition RoverPosition { get; set; }
        Orientations RoverOrientation { get; set; }
        IGridBoundary GridBoundary { get; set; }
        string Command { get; set; }
        bool IsRobotInsideBoundaries { get; }
        void Process();
        string ToString();
    }
}
