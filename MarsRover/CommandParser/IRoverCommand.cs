using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover
{
    public interface IRoverCommand
    {
        IVectorPosition InitialPosition { get; set; }
        string Command { get; set; }
    }

   
}
