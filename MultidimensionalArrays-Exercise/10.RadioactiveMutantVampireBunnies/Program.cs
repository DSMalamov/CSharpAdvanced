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

            int[,] matrix = new int[size[0], size[1]];

            int currRow = 0;
            int currCol = 0;
            bool result = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] colEl = Console.ReadLine()
                    .Split("", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colEl[col];

                    if (matrix[row, col] == 'P')
                    {
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
                    
                }
                else if (cmdArg == 'D')
                {

                }
                else if (cmdArg == 'L')
                {

                }
                else if (cmdArg == 'R')
                {

                }
            }
        }
    }
}