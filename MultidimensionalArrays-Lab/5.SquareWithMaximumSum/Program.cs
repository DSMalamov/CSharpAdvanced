namespace _5.SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[matrixSize[0], matrixSize[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] colEl = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colEl[col];
                }
            }

            int maxSquareSum = 0;
            int rowIndex = 0;
            int colIndex = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int currSum = 0;

                    if (row >= matrix.GetLength(0) -1 || col >= matrix.GetLength(1) -1)
                    {
                        continue;
                    }
                    currSum += matrix[row, col];
                    currSum += matrix[row + 1, col];
                    currSum += matrix[row, col + 1];
                    currSum += matrix[row + 1, col + 1];

                    if (currSum > maxSquareSum)
                    {
                        maxSquareSum = currSum;
                        rowIndex = row;
                        colIndex = col;
                    }

                }
            }

            Console.WriteLine($"{matrix[rowIndex, colIndex]} {matrix[rowIndex, colIndex + 1]}");
            Console.WriteLine($"{matrix[rowIndex + 1, colIndex]} {matrix[rowIndex + 1, colIndex + 1]}");
            Console.WriteLine(maxSquareSum);
        }
    }
}