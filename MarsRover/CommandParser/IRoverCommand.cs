using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover
{
    public interface IRoverCommand
    {
        IInitialPosition InitialPosition { get; set; }
        string Command { get; set; }
    }

   
}
