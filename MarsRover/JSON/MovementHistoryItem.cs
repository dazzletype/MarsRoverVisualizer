namespace MarsRover
{
    /// <summary>
    /// A class for containing primitive elements of the rover's movements to crate a simple and flat JSON object
    /// </summary>
    public class MovementHistoryItem : IMovementHistoryItem
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Orientation { get; set; }

        public MovementHistoryItem(int x, int y, string orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;
        }
      
    }
}
