﻿namespace MarsRover
{
    /// <summary>
    /// Position that determines plateau/grid size by providing a boundary coordinate originating from the lower left corner.
    /// For example, a boundary position of 1,2 results in the following grid:
    /// -------------
    /// |     |(1,2)|  
    /// -------------
    /// |     |     |  
    /// -------------
    /// |(0,0)|     |  
    /// -------------
    /// </summary>
    public class GridBoundary : IGridBoundary
    {
        public GridBoundary(int x, int y)
        {
            X = x;
            Y = y;
        }

        #region IGridBoundary Members

        public int X { get; set; }
        public int Y { get; set; }

        #endregion
    }
}