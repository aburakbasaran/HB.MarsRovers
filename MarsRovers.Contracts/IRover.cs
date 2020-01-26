using MarsRovers.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Contracts
{
    public interface IRover
    {
        public IRoverPosition CurrentPosition { get; set; }
        public IPlateau Plateau { get; set; }
        public char[] Commands { get; set; }
        void Move();
        void TurnLeft();
        void TurnRight();
        public void RunCommand(char[] commands);
        public bool ValidateRoverCurrentPositionInput(string Input);

    }
}
