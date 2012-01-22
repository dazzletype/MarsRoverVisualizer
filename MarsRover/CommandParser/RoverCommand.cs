namespace MarsRover.CommandProcessing
{

    /// <summary>
    /// A class encapsulating set of commands per rover
    /// </summary>
    public class RoverCommand
    {
        public IVectorPosition InitialPosition { get; set; }
        public string Command { get; set; }

        public RoverCommand(IVectorPosition initialPosition, string commands)
        {
            InitialPosition = initialPosition;
            Command = commands;
        }

    }


}
