using MarsRovers.Application.Commands;
using MarsRovers.Common.Enums;
using MarsRovers.Contracts;
using System;

namespace MarsRovers.Application.Services
{
    public class Rover : IRover
    {
        public IRoverPosition CurrentPosition { get;  set; }
        public IPlateau Plateau { get; set; }
        public char[] Commands { get; set; }

        #region Cons.
        public Rover(IRoverPosition roverPosition, IPlateau plateau)
        {
            this.CurrentPosition = roverPosition;
            this.Plateau = plateau;

        }
        #endregion

        #region Validation
        private bool ValidateRoverPosition()
        {
            var X = this.Plateau.XSize;
            var Y = this.Plateau.YSize;
            var returnValue = false;

            var currentRoverPosition = this.CurrentPosition;
           

            if ((currentRoverPosition.X <= X || currentRoverPosition.X >= 0) && (currentRoverPosition.Y <= Y || currentRoverPosition.Y >= 0))
            {
                returnValue = true;
            }


            return returnValue;
        }
        public bool ValidateRoverCurrentPositionInput(string Input) //Current Position Input Validation
        {
            if (String.IsNullOrWhiteSpace(Input))
            {
                return false;
            }

            var roverPosition = Input.Split(' ');
            if (roverPosition.Length == 3)
            {
                try
                {
                    var x = int.Parse(roverPosition[0]);
                    var y = int.Parse(roverPosition[1]);

                    var direction = roverPosition[2].ToUpper();
                    if (direction == "N" || direction == "S" || direction == "E" || direction == "W")
                    {
                        this.CurrentPosition.RoverDirection = (RoverDirection)Enum.Parse(typeof(RoverDirection), direction);
                        this.CurrentPosition.X = x;
                        this.CurrentPosition.Y = y;
                        return true;
                    }
                }
                catch (Exception)
                {
                }
            }
            return false;
        }

        #endregion

        #region Commands
        public void Move()
        {
            if (ValidateRoverPosition())
            {
                this.CurrentPosition = MoveCommand.Process(this.CurrentPosition);
            }
        }
        public void TurnLeft()
        {
            this.CurrentPosition.RoverDirection = LeftCommand.Process(this.CurrentPosition.RoverDirection);
        }
        public void TurnRight()
        {
            this.CurrentPosition.RoverDirection = RightCommand.Process(this.CurrentPosition.RoverDirection);
        }
        public void RunCommand(char[] commands)
        {

            if (commands.Length==0)
            {
                throw new NullReferenceException();
            }

            foreach (var letter in commands)
            {
                switch (char.ToUpper(letter))
                {
                    case 'L':
                        this.TurnLeft();
                        break;
                    case 'R':
                        this.TurnRight();
                        break;
                    case 'M':
                        this.Move();
                        break;
                    default:
                        throw new InvalidCastException();
                }
            }
        }
        #endregion

    }
}
