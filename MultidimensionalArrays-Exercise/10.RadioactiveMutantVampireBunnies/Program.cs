using System.Numerics;

namespace _10.RadioactiveMutantVampireBunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = new char[size[0], size[1]];

            int currRow = 0;
            int currCol = 0;
            string result = string.Empty;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string colEl = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colEl[col];

                    if (matrix[row, col] == 'P')
                    {
                        matrix[row, col] = '.';
                        currRow = row;
                        currCol = col;
                    }
                }
            }

            string command = Console.ReadLine();

            for (int i = 0; i < command.Length; i++)
            {
                char cmdArg = command[i];

                if (cmdArg == 'U')
                {

                    if ((currRow - 1) >= 0 && matrix[currRow - 1, currCol] == 'B')
                    {
                        result = "dead";
                        BunnySpread(size, matrix);
                        PrintResult(matrix, currRow - 1, currCol, result);
                        return;
                    }
                    currRow--;
                }
                else if (cmdArg == 'D')
                {

                    if ((currRow + 1) < matrix.GetLength(0) && matrix[currRow + 1, currCol] == 'B')
                    {
                        result = "dead";
                        BunnySpread(size, matrix);
                        PrintResult(matrix, currRow + 1, currCol, result);
                        return;
                    }
                    currRow++;
                }
                else if (cmdArg == 'L')
                {

                    if ((currCol - 1) >= 0 && matrix[currRow, currCol - 1] == 'B')
                    {
                        result = "dead";
                        BunnySpread(size, matrix);
                        PrintResult(matrix, currRow, currCol - 1, result);
                        return;
                    }
                    currCol--;
                }
                else if (cmdArg == 'R')
                {

                    if ((currCol + 1) < matrix.GetLength(1) && matrix[currRow, currCol + 1] == 'B')
                    {
                        result = "dead";
                        BunnySpread(size, matrix);
                        PrintResult(matrix, currRow, currCol + 1, result);
                        return;
                    }
                    currCol++;
                }



                BunnySpread(size, matrix);

                if (currRow < 0 || currRow == matrix.GetLength(0) ||
                    currCol < 0 || currCol == matrix.GetLength(1))
                {
                    result = "won";
                    PrintResult(matrix, currRow, currCol, result);
                    return;
                }
            }
        }

        private static void BunnySpread(int[] size, char[,] matrix)
        {
            char[,] newMatrix = new char[size[0], size[1]];

            for (int row = 0; row < size[0]; row++)
            {
                for (int col = 0; col < size[1]; col++)
                {
                    newMatrix[row, col] = matrix[row, col];
                }
            }
            //newMatrix = matrix;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (newMatrix[row, col] == 'B')
                    {   //up
                        if (row - 1 >= 0)
                        {
                            matrix[row - 1, col] = 'B';
                        }
                        //down
                        if (row + 1 < matrix.GetLength(0))
                        {
                            matrix[row + 1, col] = 'B';
                        }
                        //left
                        if (col - 1 >= 0)
                        {
                            matrix[row, col - 1] = 'B';
                        }
                        //right
                        if (col + 1 < matrix.GetLength(1))
                        {
                            matrix[row, col + 1] = 'B';
                        }
                    }
                }
            }
        }

        public static void PrintResult(char[,] matrix, int currRow, int currCol, string result)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }

            if (currCol < 0)
            {
                currCol = 0;
            }
            else if (currRow < 0)
            {
                currRow = 0;
            }
            else if (currRow >= matrix.GetLength(0))
            {
                currRow = matrix.GetLength(0) - 1;
            }
            else if (currCol >= matrix.GetLength(1))
            {
                currCol = matrix.GetLength(1) - 1;
            }
            Console.WriteLine($"{result}: {currRow} {currCol}");
        }
    }
}