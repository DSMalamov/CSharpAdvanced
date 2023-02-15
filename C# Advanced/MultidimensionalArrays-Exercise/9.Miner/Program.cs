using System.Numerics;

namespace _9.Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            char[,] matrix = new char[size, size];

            int currRow = 0;
            int currCol = 0;
            int endRow = 0;
            int endCol = 0;
            int coalCounter = 0;

            for (int row = 0; row < size; row++)
            {
                char[] colEl = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = colEl[col];

                    if (matrix[row, col] == 's')
                    {
                        currRow = row;
                        currCol = col;
                    }
                    else if (matrix[row, col] == 'c')
                    {
                        coalCounter++;
                    }
                    else if (matrix[row, col] == 'e')
                    {
                        endRow= row;
                        endCol = col;
                    }
                }
            }

            if (coalCounter <= 0)
            {
                Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
                return;
            }

            for (int i = 0; i < commands.Length; i++)
            {
                string command = commands[i];

                if (command == "up")
                {
                    if (currRow - 1 >= 0)
                    {
                        if (matrix[currRow - 1,currCol] == 'c')
                        {
                            coalCounter--;
                            matrix[currRow - 1, currCol] = '*';

                            if (coalCounter == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({currRow - 1}, {currCol})");
                                return;
                            }

                        }
                        else if (matrix[currRow - 1, currCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({currRow - 1}, {currCol})");
                            return;
                        }

                        currRow--;

                    }
                }
                else if (command == "right")
                {
                    if (currCol + 1 < size )
                    {
                        if (matrix[currRow, currCol + 1] == 'c')
                        {
                            coalCounter--;
                            matrix[currRow, currCol + 1] = '*';

                            if (coalCounter == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({currRow}, {currCol + 1})");
                                return;

                            }

                        }
                        else if (matrix[currRow, currCol + 1] == 'e')
                        {
                            Console.WriteLine($"Game over! ({currRow}, {currCol + 1})");
                            return;
                        }

                        currCol++;
                    }
                }
                else if (command == "left")
                {
                    if (currCol - 1 >= 0)
                    {
                        if (matrix[currRow, currCol - 1] == 'c')
                        {
                            coalCounter--;
                            matrix[currRow, currCol - 1] = '*';

                            if (coalCounter == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({currRow}, {currCol - 1})");
                                return;

                            }

                        }
                        else if (matrix[currRow, currCol - 1] == 'e')
                        {
                            Console.WriteLine($"Game over! ({currRow}, {currCol - 1})");
                            return;
                        }

                        currCol--;
                    }
                }
                else if (command == "down")
                {
                    if (currRow + 1 < size)
                    {
                        if (matrix[currRow + 1, currCol] == 'c')
                        {
                            coalCounter--;
                            matrix[currRow + 1, currCol] = '*';

                            if (coalCounter == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({currRow + 1}, {currCol})");
                                return;
                            }

                        }
                        else if (matrix[currRow + 1, currCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({currRow + 1}, {currCol})");
                            return;
                        }

                        currRow++;

                    }
                }
            }

            Console.WriteLine($"{coalCounter} coals left. ({currRow}, {currCol})");

        }
    }
}