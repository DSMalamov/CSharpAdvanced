using System;
using System.Data;
using System.Numerics;

namespace _08.WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] wall = new char[n, n];

            int vankoRow = -1;
            int vankoCol = -1;
            int copyRow = 0;
            int copyCol = 0;
            int holeCounter = 1;
            bool isElectrocuted = false;
            int rodsCount = 0;

            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    wall[row, col] = rowData[col];

                    if (rowData[col] == 'V')
                    {
                        vankoCol = col;
                        vankoRow = row;
                    }
                }
            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                copyRow = vankoRow;
                copyCol = vankoCol;

                if (command == "up" && vankoRow > 0)
                {
                    copyRow--;
                }
                else if(command == "down" && vankoRow < wall.GetLength(0) - 1)
                {
                    copyRow++;
                }
                else if(command == "left" && vankoCol > 0)
                {
                    copyCol--;
                }
                else if(command == "right" && vankoCol < wall.GetLength(1) - 1)
                {
                    copyCol++;
                }

                if (wall[copyRow,copyCol] == 'C')
                {
                    wall[copyRow, copyCol] = 'E';
                    holeCounter++;
                    wall[vankoRow, vankoCol] = '*';
                    isElectrocuted = true;
                    break;
                }
                else if (wall[copyRow,copyCol] == 'R')
                {
                    Console.WriteLine("Vanko hit a rod!");
                    rodsCount++;
                }
                else if (wall[copyRow, copyCol] == '*')
                {
                    Console.WriteLine($"The wall is already destroyed at position [{copyRow}, {copyCol}]!");
                    wall[vankoRow, vankoCol] = '*';
                    vankoRow = copyRow; 
                    vankoCol = copyCol;
                }
                else if (wall[copyRow, copyCol] == '-')
                {
                    wall[vankoRow, vankoCol] = '*';
                    vankoRow = copyRow;
                    vankoCol = copyCol;
                    holeCounter++;
                }
            }

            if (isElectrocuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holeCounter} hole(s).");
            }
            else
            {
                wall[vankoRow, vankoCol] = 'V';
                Console.WriteLine($"Vanko managed to make {holeCounter} hole(s) and he hit only {rodsCount} rod(s).");
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(wall[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
