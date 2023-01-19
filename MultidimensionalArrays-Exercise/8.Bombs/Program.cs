namespace _8.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] colEl = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = colEl[col];
                }
            }


            string[] bombsInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int exp = 0; exp < bombsInfo.Length; exp++)
            {
                string bombCoor = bombsInfo[exp];
                int row = bombCoor[0] - 48;
                int col = bombCoor[2] - 48;

                int cellValue = matrix[row, col];

                if (cellValue <= 0)
                {
                    continue;
                }

                matrix[row, col] = 0;

                //up-left
                if (row - 1 >= 0 && col - 1 >=0)
                {
                    if (matrix[row - 1, col - 1] > 0 )
                    {
                        matrix[row - 1, col - 1] -= cellValue;

                    }


                }
                // up - up
                if (row - 1 >= 0 )
                {
                    if (matrix[row - 1, col] > 0)
                    {
                        matrix[row - 1, col] -= cellValue;
                    }
                }
                // up - right
                if (row - 1 >= 0 && col + 1 < matrix.GetLength(1))
                {
                    if (matrix[row - 1, col + 1] > 0)
                    {
                        matrix[row - 1, col + 1] -= cellValue;
                    }
                }
                //horizontal - left
                if (col - 1 >= 0)
                {
                    if (matrix[row, col - 1] > 0)
                    {
                        matrix[row, col - 1] -= cellValue;
                    }
                }
                //horizontal - right
                if (col + 1 < matrix.GetLength(1))
                {
                    if (matrix[row, col + 1] > 0)
                    {
                        matrix[row, col + 1] -= cellValue;
                    }
                }
                //down - left
                if (row + 1 < matrix.GetLength(0) && col - 1 >= 0)
                {
                    if (matrix[row + 1, col - 1] > 0)
                    {
                        matrix[row + 1, col - 1] -= cellValue;
                    }
                }
                // down - down
                if (row + 1 < matrix.GetLength(0))
                {
                    if (matrix[row + 1, col] > 0)
                    {
                        matrix[row + 1, col] -= cellValue;
                    }
                }
                // down - right
                if (row + 1 < matrix.GetLength(0) && col + 1 < matrix.GetLength(1))
                {
                    if (matrix[row + 1, col + 1] > 0)
                    {
                        matrix[row + 1, col + 1] -= cellValue;
                    }
                }



            }

            int aliveCells = 0;
            int aCSum = 0;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        aCSum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {aCSum}");

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
            

            


        }
    }
}