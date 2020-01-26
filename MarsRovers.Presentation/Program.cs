using MarsRovers.Contracts;
using MarsRovers.Infrastructure.DI;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRovers.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = Installer.Configure();
            var oneMoreRover = true;
            var validateSize = false;
            var plateauSizeInput = String.Empty;

            var plateau = serviceProvider.GetService<IPlateau>();
            Console.WriteLine("Welcome the MarsRover Project");

            #region Plateau Size Validation
        
            while (!validateSize)
            {
                Console.WriteLine("Please enter the plateau size:       Etc. (5 5) ");

                plateauSizeInput = Console.ReadLine();
                validateSize = plateau.ValidatePlateauSizeInput(plateauSizeInput);

                if (!validateSize)
                {
                    Console.WriteLine("Plateau size is not valid");
                }
            }

            #endregion

            #region Inputs
            while (oneMoreRover)
            {
                bool validateRoverCommand = false, validateRoverPosition = false;

                string roverCommandInput = String.Empty, roverPositionInput = String.Empty;

                var rover = serviceProvider.GetService<IRover>();

                #region PositionAndCommandValidation

                while (!validateRoverPosition)
                {
                    Console.WriteLine("Please enter the rover position :    Etc. (0 0 w)");
                    roverPositionInput = Console.ReadLine();
                    validateRoverPosition = rover.ValidateRoverCurrentPositionInput(roverPositionInput);

                    if (!validateRoverPosition)
                    {
                        Console.WriteLine("Rover position input is not valid");
                    }
                }


                while (!validateRoverCommand)
                {
                    Console.WriteLine("Please enter the rover command :     Etc. (lmmlmrm)");
                    roverCommandInput = Console.ReadLine();

                    if (String.IsNullOrWhiteSpace(roverCommandInput))
                        Console.WriteLine("Rover command input is not valid");
                    else
                        validateRoverCommand = true;

                }

                #endregion

                rover.Commands = roverCommandInput.ToCharArray();

                rover.Plateau = plateau;
                plateau.Rovers.Add(rover);


                Console.WriteLine("One More Rover ? (Y)");

                var oneMoreRoverKey = Console.ReadLine();

                if (oneMoreRoverKey.ToUpper() != "Y")
                {
                    oneMoreRover = false;
                }
            }

            #endregion

            #region Results
            var counter = 1;
            foreach (var rvr in plateau.Rovers)
            {
                rvr.RunCommand(rvr.Commands);

                Console.WriteLine("Mars Rovers Project Results " + counter++ + ":");

                Console.WriteLine($"{rvr.CurrentPosition.X} " +
              $"{rvr.CurrentPosition.Y} " +
              $"{rvr.CurrentPosition.RoverDirection.ToString()}");
            }
            #endregion

            Console.ReadKey();

        }
    }
}
