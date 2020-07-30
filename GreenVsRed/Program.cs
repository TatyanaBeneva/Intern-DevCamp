using System;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;

namespace GreenVSRed
{
    class Program
    {
        static void Main(string[] args)
        {
            Input values = new Input();
            values.GetGridSize();
            values.GetGrid();
            values.GetCoordinatesForTheWantedCell();
            values.GetTheNumOfGreens();
            values.PrintTheResult();
        }

    }
}
