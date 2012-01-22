namespace MarsRover.CommandProcessing
{

    /// <summary>
    /// A class encapsulating set of commands per rover
    /// </summary>
    public class RoverCommand : IRoverCommand
    {
        public IInitialPosition InitialPosition { get; set; }
        public string Command { get; set; }

        public RoverCommand(IInitialPosition initialPosition, string commands)
        {
            InitialPosition = initialPosition;
            Command = commands;
        }

    }


}
