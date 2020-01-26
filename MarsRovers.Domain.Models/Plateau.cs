using MarsRovers.Contracts;
using System;
using System.Collections.Generic;

namespace MarsRovers.Domain.Models
{
    public class Plateau : IPlateau
    {
        public int XSize { get;  set; }
        public int YSize { get; set; }

        public IList<IRover> Rovers { get; set; }

        public Plateau()
        {
            this.Rovers = new List<IRover>();
        }

        public bool ValidatePlateauSizeInput(string Inputs)
        {
            var returnVal = false;

            if (!string.IsNullOrWhiteSpace(Inputs))
            {
                var gridSize = Inputs.Split(' ');
                if (gridSize.Length == 2)
                {
                    int gridX;
                    if (int.TryParse(gridSize[0], out gridX))
                    {
                        int gridY;
                        if (int.TryParse(gridSize[1], out gridY))
                        {
                            this.XSize = gridX;
                            this.YSize = gridY;
                            returnVal = true;
                        }
                    }

                }
            }
            return returnVal;
        }
    }
}
