using MarsRovers.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Contracts
{
    public interface IRoverPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public RoverDirection RoverDirection { get; set; }
    }
}
