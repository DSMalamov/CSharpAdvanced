namespace _4.MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[size[0], size[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                int[] colEl = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col= 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colEl[col];
                }
            }

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArg = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (cmdArg[0] == "swap" && cmdArg.Length >= 0 && cmdArg.Length <= 5 
                    && int.Parse(cmdArg[1]) >= 0 && int.Parse(cmdArg[1]) < matrix.GetLength(0)
                    && int.Parse(cmdArg[2]) >= 0 && int.Parse(cmdArg[2]) < matrix.GetLength(1)
                    && int.Parse(cmdArg[3]) >= 0 && int.Parse(cmdArg[3]) < matrix.GetLength(0)
                    && int.Parse(cmdArg[4]) >= 0 && int.Parse(cmdArg[4]) < matrix.GetLength(1))
                {
                    int copy = matrix[int.Parse(cmdArg[1]), int.Parse(cmdArg[2])];
                    matrix[int.Parse(cmdArg[1]), int.Parse(cmdArg[2])] = matrix[int.Parse(cmdArg[3]), int.Parse(cmdArg[4])];
                    matrix[int.Parse(cmdArg[3]), int.Parse(cmdArg[4])] = copy;

                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            Console.Write($"{matrix[row, col]} ");
                        }

                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}