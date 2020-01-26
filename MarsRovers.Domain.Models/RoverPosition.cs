using MarsRovers.Common.Enums;
using MarsRovers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Domain.Models
{
    public class RoverPosition : IRoverPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public RoverDirection RoverDirection { get; set; }

        public RoverPosition(RoverDirection roverdirection = RoverDirection.N, int x = 0, int y = 0)
        {
            this.X = x;
            this.Y = y;
            this.RoverDirection = roverdirection;
        }
    }
}
