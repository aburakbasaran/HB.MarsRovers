using MarsRovers.Common.Enums;
using MarsRovers.Contracts;
using MarsRovers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Application.Commands
{
    public class LeftCommand
    {    
        public static RoverDirection Process(RoverDirection roverDirection)
        {
            RoverDirection currentRoverDirection = roverDirection;

            switch (roverDirection)
            {
                case RoverDirection.N:
                    currentRoverDirection = RoverDirection.W;
                    break;
                case RoverDirection.E:
                    currentRoverDirection = RoverDirection.N;
                    break;
                case RoverDirection.S:
                    currentRoverDirection = RoverDirection.E;
                    break;
                case RoverDirection.W:
                    currentRoverDirection = RoverDirection.S;
                    break;
                default:
                    throw new InvalidOperationException();
            }
            return currentRoverDirection;

        }
    }
}
