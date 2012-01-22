using System.Collections.Generic;

namespace MarsRover
{
    public interface IInputParser
    {
        IGridBoundary GridBoundary { get; set; }
        IList<IRoverCommand> RoverInstructions { get; set; }

        bool ReadInput(string input);
    }
}
