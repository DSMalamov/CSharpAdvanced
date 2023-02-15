using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12.BeaverAtWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<char> branches = new List<char>();

            char[,] matrix = new char[n,n];
            int bRow = -1;
            int bCol = -1;
            int branchesCounter = 0;

            for (int row = 0; row < n; row++)
            {
                char[] rowData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row,col] = rowData[col];

                    if (matrix[row,col] == 'B')
                    {
                        matrix[row, col] = '-';
                        bRow= row;
                        bCol= col;
                    }
                    else if (char.IsLower(rowData[col]) && rowData[col] != '-')
                    {
                        branchesCounter++;
                    }
                }
            }

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                
                if (command == "up")
                {
                    bRow--;

                    if (bRow < 0)
                    {
                        bRow = 0;

                        if (branches.Count > 0)
                        {
                            branches.RemoveAt(branches.Count - 1);
                        }
                    }
                }
                else if (command == "down")
                {
                    bRow++;

                    if (bRow >= matrix.GetLength(0))
                    {
                        bRow = matrix.GetLength(0) - 1;

                        if (branches.Count > 0)
                        {
                            branches.RemoveAt(branches.Count - 1);
                        }
                    }
                }
                else if (command == "left")
                {
                    bCol--;

                    if (bCol < 0)
                    {
                        bCol = 0;

                        if (branches.Count > 0)
                        {
                            branches.RemoveAt(branches.Count - 1);
                        }
                    }
                }
                else if (command == "right")
                {
                    bCol++;

                    if (bCol >= matrix.GetLength(1))
                    {
                        bCol = matrix.GetLength(1) - 1;

                        if (branches.Count>0)
                        {
                            branches.RemoveAt(branches.Count - 1);
                        }
                    }
                }

               
                char cageValue = matrix[bRow, bCol];
                matrix[bRow, bCol] = '-';

                if (char.IsLower(cageValue) && cageValue != '-')
                {
                    branches.Add(cageValue);
                    branchesCounter--;

                    if (branchesCounter == 0)
                    {
                        break;
                    }
                }
                else if (cageValue == 'F')
                {

                    if (bRow == 0 || bRow == n - 1 || bCol == 0 || bCol == n - 1)
                    {
                        if (command == "up")
                        {
                            bRow = n - 1;
                        }
                        else if (command == "down")
                        {
                            bRow = 0;
                        }
                        else if (command == "left")
                        {
                            bCol = n-1;
                        }
                        else if (command == "right")
                        {
                            bCol= 0;
                        }
                    }
                    else
                    {
                        if (command == "up")
                        {
                            bRow = 0;
                        }
                        else if (command == "down")
                        {
                            bRow = n-1;
                        }
                        else if (command == "left")
                        {
                            bCol = 0;
                        }
                        else if (command == "right")
                        {
                            bCol = n - 1;
                        }
                    }
                }
            }

            matrix[bRow, bCol] = 'B';

            if (branchesCounter == 0)
            {
                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {branchesCounter} branches left.");
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
