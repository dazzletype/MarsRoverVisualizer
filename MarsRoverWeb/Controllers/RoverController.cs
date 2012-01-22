using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MarsRover;

namespace MarsRoverVisualizer.Controllers
{
    /// <summary>
    /// Controller to get rover movements.
    /// Current version only handles first rover in list; future implementations will handle all rovers in list.
    /// </summary>
    public class RoverController : Controller
    {

        // sample input file for rover setup
        private const string SampleInput = @"5 5
                                       1 2 N
                                       LMLMLMLMM
                                       3 3 E
                                       MMRMMRMRRM";

        private IInputParser commandProcessor = new InputParser();
        private IList<Rover> rovers = new List<Rover>();

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Service to return boundary coordinates to establish grid size
        /// </summary>
        /// <returns>coordinates in JSON format</returns>
        [HttpPost]
        public JsonResult GetPlateauCoordinates()
        {
            SetupRovers();
            IGridBoundary gridBoundary = commandProcessor.GridBoundary;

            if (ModelState.IsValid)
            {
                var data = new { gridBoundary.X, gridBoundary.Y };        // hardcoded based on sample input for simplicity
                return Json(data);
            }

            return null;
        }

        /// <summary>
        /// Service to return a rover's initial coordinates
        /// </summary>
        /// <returns>X,Y,Coordinate information in JSON format</returns>
        [HttpPost]
        public JsonResult GetInitialPosition()
        {
            SetupRovers();

            if (ModelState.IsValid)
            {
                var data = new {rovers.First().RoverInitialPosition.X, rovers.First().RoverInitialPosition.Y, rovers.First().RoverInitialPosition.Orientation };        // hardcoded based on sample input for simplicity
                return Json(data);
            }

            return null;
        }

        /// <summary>
        /// Gets a trail of the rovers movements
        /// </summary>
        /// <returns>list of coordinates and orientation in JSON format</returns>
        [HttpPost]
        public JsonResult GetRoverHistory()
        {
            SetupRovers();

            if (ModelState.IsValid)
            {
                rovers.First().Process();
                return Json(rovers.First().MovementHistory);
            }
            
            return null;
        }


        /// <summary>
        /// Reads input file and populates the list of rovers ready to be processed
        /// </summary>
        private void SetupRovers()
        {
            commandProcessor.ReadInput(SampleInput);
            IGridBoundary gridBoundary = commandProcessor.GridBoundary;

            foreach (var roverInstruction in commandProcessor.RoverInstructions)
            {
                Console.WriteLine(roverInstruction.InitialPosition);
                Console.WriteLine(roverInstruction.Command);

                rovers.Add(new Rover(roverInstruction.InitialPosition, roverInstruction.Command, gridBoundary));
            }

        }
    }
}
