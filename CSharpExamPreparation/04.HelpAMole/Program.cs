using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.HelpAMole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[,] matrix = new string[n,n];
            int moleRow = 0;
            int moleCol = 0;
            int firstSrow = 0;
            int firstScol = 0;
            int secondSrow = 0;
            int secondScol = 0;
            bool isFirst = true;
            int points = 0;
            bool isMoleWon = false;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                List<char> list = new List<char>();

                foreach (char c in input) 
                { 
                    list.Add(c);
                }

                for (int y = 0; y < n; y++)
                {
                    matrix[i,y] = list[y].ToString();

                    if (list[y] == 'M')
                    {
                        moleCol= y;
                        moleRow= i;
                    }
                    else if (list[y] == 'S')
                    {
                        if (isFirst)
                        {
                            firstScol = y;
                            firstSrow = i;
                            isFirst= false;
                        }
                        else
                        {
                            secondScol = y;
                            secondSrow = i;
                        }
                    }
                }

            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                if (command == "up")
                {
                    if (moleRow - 1 < 0)
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                        continue;
                    }
                    else
                    {
                        matrix[moleRow, moleCol] = "-";
                        moleRow--;
                    }
                }
                else if (command == "down")
                {
                    if (moleRow + 1 >= matrix.GetLength(0))
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                        continue;
                    }
                    else
                    {
                        matrix[moleRow, moleCol] = "-";
                        moleRow++;
                    }
                }
                else if (command == "left")
                {
                    if (moleCol - 1 < 0)
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                        continue;
                    }
                    else
                    {
                        matrix[moleRow, moleCol] = "-";
                        moleCol--;
                    }
                }
                else if (command == "right")
                {
                    if (moleCol + 1 >= matrix.GetLength(1))
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                        continue;
                    }
                    else
                    {
                        matrix[moleRow, moleCol] = "-";
                        moleCol++;

                    }
                }
                

                if (matrix[moleRow,moleCol] == "S")
                {
                    if (moleRow == firstSrow && moleCol == firstScol)
                    {
                        matrix[moleRow, moleCol] = "-";
                        moleCol = secondScol;
                        moleRow = secondSrow;
                        matrix[moleRow, moleCol] = "-";
                    }
                    else if (moleRow == secondSrow && moleCol == secondScol)
                    {
                        matrix[moleRow, moleCol] = "-";
                        moleCol = firstScol;
                        moleRow = firstSrow;
                        matrix[moleRow, moleCol] = "-";
                    }

                    points -= 3;

                    if (points < 0)
                    {
                        points = 0;
                    }
                   
                }
                else if (matrix[moleRow, moleCol] == "-")
                {
                    continue;
                }
                else
                {
                    int currPoints = int.Parse(matrix[moleRow, moleCol]);
                    points += currPoints;

                    if (points >= 25)
                    {
                        isMoleWon = true;
                        break;
                    }
                }


            }

            matrix[moleRow, moleCol] = "M";

            if (isMoleWon)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }




        }
    }
}
