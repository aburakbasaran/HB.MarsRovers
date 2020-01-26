using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Contracts
{
    public interface IPlateau
    {
        public int XSize { get; set; }
        public int YSize { get; set; }
        public IList<IRover> Rovers { get; set; }
        public bool ValidatePlateauSizeInput(string Inputs);
    }
}
