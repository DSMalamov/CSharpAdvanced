using System;

namespace _14.Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int officerRow = -1;
            int officerCol = -1;
            int coinsCount = 0;
            int firstMRow = -1;
            int firstMCol = -1;
            int secondMRow = -1;
            int secondMCol = -1;
            bool isOut =  false;
            bool isFirst = true;

            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];
                    if (rowData[col] == 'A')
                    {
                        officerRow = row;
                        officerCol = col;
                        matrix[officerRow, officerCol] = '-';
                    }
                    else if (rowData[col] == 'M' && isFirst)
                    {
                        firstMRow = row;
                        firstMCol = col;
                        isFirst = false;
                    }
                    else if (rowData[col] == 'M')
                    {
                        secondMRow = row;
                        secondMCol = col;
                    }
                }
            }

            string command;

            while (coinsCount < 65)
            {
                command = Console.ReadLine();
                
                if (command == "up")
                {
                    officerRow--;
                    
                    if (officerRow < 0)
                    {
                        isOut = true;
                        break;
                    }
                }
                else if (command == "down")
                {
                    officerRow++;

                    if (officerRow >= matrix.GetLength(0))
                    {
                        isOut = true;
                        break;
                    }
                }
                else if (command == "left")
                {
                    officerCol--;

                    if (officerCol < 0)
                    {
                        isOut = true;
                        break;
                    }
                }
                else if (command == "right")
                {
                    officerCol++;

                    if (officerCol >= matrix.GetLength(1))
                    {
                        isOut = true;
                        break;
                    }
                }

                char ch = matrix[officerRow, officerCol];
                matrix[officerRow, officerCol] = '-';

                if (char.IsDigit(ch))
                {
                    int digit = int.Parse(ch.ToString());
                    coinsCount += digit;
                }
                else if (ch == 'M')
                {
                    if (officerRow == firstMRow && officerCol == firstMCol)
                    {
                        officerRow = secondMRow;
                        officerCol = secondMCol;
                    }
                    else
                    {
                        officerRow= firstMRow;
                        officerCol= firstMCol;
                    }
                    matrix[firstMRow, firstMCol] = '-';
                    matrix[secondMRow, secondMCol] = '-';
                }
            }

            if (isOut)
            {
                Console.WriteLine("I do not need more swords!");
                Console.WriteLine($"The king paid {coinsCount} gold coins.");
            }
            else
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
                Console.WriteLine($"The king paid {coinsCount} gold coins.");
                matrix[officerRow, officerCol] = 'A';
            }

            

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
