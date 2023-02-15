using System;

namespace _10.TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[,] matrix = new string[n,n];

            for (int row = 0; row < n; row++)
            {
                string[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < n; col++)
                {
                    matrix[row,col] = rowData[col];
                }
            }

            string command;
            int collectedBT = 0;
            int collectedWT = 0;
            int collectedST = 0;
            int atenT = 0;

            while ((command = Console.ReadLine()) != "Stop the hunt")
            {
                string[] cmdArg = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = cmdArg[0];

                if (type == "Collect")
                {
                    int row = int.Parse(cmdArg[1]);
                    int col = int.Parse(cmdArg[2]);

                    if (row >=0 && row < matrix.GetLength(0) &&
                        col >= 0 && col < matrix.GetLength(1))
                    {
                        if (matrix[row, col] == "B")
                        {
                            collectedBT++;
                            matrix[row, col] = "-";
                        }
                        else if (matrix[row, col] == "S")
                        {
                            collectedST++;
                            matrix[row, col] = "-";
                        }
                        else if (matrix[row, col] == "W")
                        {
                            collectedWT++;
                            matrix[row, col] = "-";
                        }
                    }
                    
                }
                else if (type == "Wild_Boar")
                {
                    int row = int.Parse(cmdArg[1]);
                    int col = int.Parse(cmdArg[2]);
                    string direction = cmdArg[3];

                    if (direction == "up")
                    {
                        for (int i = row; i >= 0; i-=2)
                        {
                            if (matrix[i, col] == "B" || matrix[i, col] == "W" || matrix[i, col] == "S")
                            {
                                atenT++;
                            }
                            matrix[i, col] = "-";
                        }
                    }
                    else if (direction == "down")
                    {
                        for (int i = row; i < matrix.GetLength(0); i+=2)
                        {
                            if (matrix[i, col] == "B" || matrix[i, col] == "W" || matrix[i, col] == "S")
                            {
                                atenT++;
                            }
                            matrix[i, col] = "-";
                        }
                    }
                    else if (direction == "left")
                    {
                        for (int i = col; i >= 0; i-=2)
                        {
                            if (matrix[row, i] == "B" || matrix[row, i] == "W" || matrix[row, i] == "S")
                            {
                                atenT++;
                            }
                            matrix[row, i] = "-";
                        }
                    }
                    else if (direction == "right")
                    {
                        for (int i = col; i < matrix.GetLength(1); i+=2)
                        {
                            if (matrix[row, i] == "B" || matrix[row, i] == "W" || matrix[row, i] == "S")
                            {
                                atenT++;
                            }
                            matrix[row, i] = "-";
                        }
                    }
                }
            }

            Console.WriteLine($"Peter manages to harvest {collectedBT} black," +
                $" {collectedST} summer, and {collectedWT} white truffles.");

            Console.WriteLine($"The wild boar has eaten {atenT} truffles.");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }

    }
}
