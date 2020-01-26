using MarsRovers.Common.Enums;
using System;


namespace MarsRovers.Application.Commands
{
    public class RightCommand 
    {    
        public static RoverDirection Process(RoverDirection roverDirection)
        {
            RoverDirection currentRoverDirection = roverDirection;

            switch (roverDirection)
            {
                case RoverDirection.N:
                    currentRoverDirection = RoverDirection.E;
                    break;
                case RoverDirection.E:
                    currentRoverDirection = RoverDirection.S;
                    break;
                case RoverDirection.S:
                    currentRoverDirection = RoverDirection.W;
                    break;
                case RoverDirection.W:
                    currentRoverDirection = RoverDirection.N;
                    break;
                default:
                    throw new InvalidOperationException();
            }
            return currentRoverDirection;

        }
    }
}
