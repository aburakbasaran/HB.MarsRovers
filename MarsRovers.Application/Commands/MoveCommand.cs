using MarsRovers.Common.Enums;
using MarsRovers.Contracts;
using MarsRovers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Application.Commands
{
    public class MoveCommand 
    {    
        public static IRoverPosition Process(IRoverPosition roverPosition)
        {
            IRoverPosition currentRoverPosition = roverPosition;

            switch (roverPosition.RoverDirection)
            {
                case RoverDirection.N:
                    currentRoverPosition = new RoverPosition(roverPosition.RoverDirection, roverPosition.X, roverPosition.Y + 1);
                    break;
                case RoverDirection.S:
                    currentRoverPosition = new RoverPosition(roverPosition.RoverDirection, roverPosition.X, roverPosition.Y - 1);
                    break;
                case RoverDirection.W:
                    currentRoverPosition = new RoverPosition(roverPosition.RoverDirection, roverPosition.X - 1, roverPosition.Y);
                    break;
                case RoverDirection.E:
                    currentRoverPosition = new RoverPosition(roverPosition.RoverDirection, roverPosition.X + 1, roverPosition.Y);
                    break;
                default:
                    throw new InvalidOperationException();
            }

            return currentRoverPosition;

        }
    }
}
