using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GreenVSRed
{
    class Input
    {
        public Input()
        {

        }
        public int x { get; set; }
        public int y { get; set; }
        public int[][] matrix { get; set; }
        public int cellX { get; set; }
        public int cellY { get; set; }
        public int rounds { get; set; }
        public int green { get; set; }

        public void GetGridSize()
        {
            Console.WriteLine("Please enter the grid coordinates with the same formate: X,Y");

            // Taking the coordinates for building the grid

            int[] coordinates = Console.ReadLine().Split(",").Select(int.Parse).ToArray();
            x = coordinates[0];
            y = coordinates[1];

            // Cheking for invalid input that don't meet on the condition

            while (y >= 1000 || x > y)
            {
                Console.WriteLine("You have incorect input. Please enter the coordinates again:");
                int[] coordinatesInput = Console.ReadLine().Split(",").Select(int.Parse).ToArray();
                x = coordinatesInput[0];
                y = coordinatesInput[1];
            }
        }

        public void GetGrid()
        {
            Console.WriteLine("Please enter the zero grid, row by row:");

            // Fill in the grid
            int[][] matrixx = new int[y][];

            for (int i = 0; i < y; i++)
            {
                string currentRow = Console.ReadLine();

                //Checking if the given input is larger then given coordinate for horizontal

                if (currentRow.Length != x)
                {
                    Console.WriteLine($"The simbols are more than X. Please write exacly {x} simbols:");
                    currentRow = Console.ReadLine();
                }

                // Makeing the input into char array for takeing each one of the characters all alone

                char[] v = currentRow.ToCharArray();

                // Converting the char array into array of numbers for better useing

                matrixx[i] = Array.ConvertAll(v, c => (int)Char.GetNumericValue(c));
            }

            matrix = matrixx;
        }

        public void GetCoordinatesForTheWantedCell()
        {
            Console.WriteLine("Please write coordinates of the cell you want to check and the rouds:");

            // Takeing the coordinates of the cell that we want to check and the numbers of rounds for whos we gona
            // check how many times the wanted cell will be 1 (green)

            int[] coorsAndRounds = Console.ReadLine().Split(",").Select(int.Parse).ToArray();
            cellX = coorsAndRounds[0];
            cellY = coorsAndRounds[1];
            rounds = coorsAndRounds[2];

            //Checking if the given coordinates are in the boundries if the grid

            while (cellX >= x || cellY >= y)
            {
                Console.WriteLine("The cell is outside the boundries of the grid! Please make your choice again:");               
                int[] coorsAndRoundsChecked = Console.ReadLine().Split(",").Select(int.Parse).ToArray();
                cellX = coorsAndRoundsChecked[0];
                cellY = coorsAndRoundsChecked[1];
                rounds = coorsAndRoundsChecked[2];
            }
        }

        public void GetTheNumOfGreens()
        {
            // Changeing the grid for every round

            for (int i = 0; i < rounds; i++)
            {
                // Makeing another array to keep the next grid

                int[][] result = new int[y][];

                // Going around each cell , to change it by the given rules

                for (int row = 0; row < y; row++)
                {
                    result[row] = new int[x];

                    for (int col = 0; col < x; col++)
                    {
                        // We make veriable to count green neighbours

                        int count = 0;

                        // We are checking the neighbours of the current cell if it's green (1) or red (0)

                        if (row >= 1 && col >= 1)
                        {
                            if (matrix[row - 1][col - 1] == 1) { count++; }
                        }

                        if (row >= 1)
                        {
                            if (matrix[row - 1][col] == 1) { count++; }
                        }

                        if (row >= 1 && x > col + 1)
                        {
                            if (matrix[row - 1][col + 1] == 1) { count++; }
                        }

                        if (col >= 1)
                        {
                            if (matrix[row][col - 1] == 1) { count++; }
                        }

                        if (x > col + 1)
                        {
                            if (matrix[row][col + 1] == 1) { count++; }
                        }

                        if (y > row + 1 && col >= 1)
                        {
                            if (matrix[row + 1][col - 1] == 1) { count++; }
                        }

                        if (y > row + 1)
                        {
                            if (matrix[row + 1][col] == 1) { count++; }
                        }

                        if (y > row + 1 && x > col + 1)
                        {
                            if (matrix[row + 1][col + 1] == 1) { count++; }
                        }

                        // Checking if the cell is going to turn green or red

                        switch (matrix[row][col])
                        {
                            case 0:
                                if (count == 3 || count == 6)
                                {
                                    result[row][col] = 1;

                                    if (row == cellY && col == cellX) { green++; }
                                }
                                else { result[row][col] = 0; }
                                break;
                            case 1:
                                if (count == 2 || count == 3 || count == 6)
                                {
                                    result[row][col] = 1;

                                    if (row == cellY && col == cellX) { green++; }
                                }
                                else { result[row][col] = 0; }
                                break;
                        }
                    }
                }

                matrix = result;
            }
        }

        public void PrintTheResult()
        {
            Console.WriteLine($"You have {green} times green color.");
        }
    }
}
