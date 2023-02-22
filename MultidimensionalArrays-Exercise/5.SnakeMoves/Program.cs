namespace _5.SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string word = Console.ReadLine();
            int wordIndex = 0;

            char[,] matrix = new char[size[0], size[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (wordIndex >= word.Length)
                        {
                            wordIndex = 0;
                        }
                        matrix[row, col] = word[wordIndex];
                        wordIndex++;
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        if (wordIndex >= word.Length)
                        {
                            wordIndex = 0;
                        }
                        matrix[row, col] = word[wordIndex];
                        wordIndex++;
                    }
                }
                
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }

        }
    }
}