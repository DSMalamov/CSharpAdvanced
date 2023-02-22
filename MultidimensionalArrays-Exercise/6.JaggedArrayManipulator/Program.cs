namespace _6.JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] colEl = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                jaggedArray[row] = colEl;

                if (row > 0)
                {
                    if (jaggedArray[row].Length == jaggedArray[row - 1].Length)
                    {
                        for (int i = 0; i < jaggedArray[row].Length; i++)
                        {
                            jaggedArray[row][i] *= 2;
                            jaggedArray[row - 1][i] *= 2;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < jaggedArray[row - 1].Length; i++)
                        {
                            jaggedArray[row - 1][i] /= 2;
                        }

                        for (int i = 0; i < jaggedArray[row].Length; i++)
                        {
                            jaggedArray[row][i] /= 2;
                        }
                    }
                }
                
            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArg = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    
                int row = int.Parse(cmdArg[1]);
                int col = int.Parse(cmdArg[2]);

                if (cmdArg[0] == "Add")
                {
                    if (row >= 0 && row < jaggedArray.Length
                        && col >= 0 && col < jaggedArray[row].Length)
                    {
                        jaggedArray[int.Parse(cmdArg[1])][int.Parse(cmdArg[2])] += int.Parse(cmdArg[3]);
                    }
                }
                else if (cmdArg[0] == "Subtract")
                {
                    if (row >= 0 && row < jaggedArray.Length
                        && col >= 0 && col < jaggedArray[row].Length)
                    {
                        jaggedArray[int.Parse(cmdArg[1])][int.Parse(cmdArg[2])] -= int.Parse(cmdArg[3]);
                    }
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write($"{jaggedArray[i][j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}