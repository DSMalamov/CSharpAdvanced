using System;

namespace _18.TheBattleOfTheFiveArmies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int armyRow = -1;
            int armyCol = -1;
            char[,] matrix = new char[n, n];
            bool isDead = false;
            

            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];

                    if (matrix[row, col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;
                        matrix[armyRow, armyCol] = '-';
                    }
                }
            }

            

            while(armor > 0)
            {
                string[] cmdArg = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = cmdArg[0];
                matrix[int.Parse(cmdArg[1]), int.Parse(cmdArg[2])] = 'O';

                if (command == "up")
                {
                    armyRow--;
                    
                }
                else if (command == "down")
                {
                    armyRow++;
                }
                else if(command == "left")
                {
                    armyCol--;
                }
                else if (command == "right")
                {
                    armyCol++;
                }

                if (IsOutside(ref armor, ref armyRow, ref armyCol, matrix))
                {
                    armor--;
                    continue;
                }

                if (matrix[armyRow,armyCol] == '-')
                {
                    armor--;

                    if (IsDead(armor, armyRow, armyCol, matrix, isDead))
                    {
                        break;
                    }
                }
                else if (matrix[armyRow, armyCol] == 'O')
                {
                    armor -= 3;

                    if (IsDead(armor, armyRow, armyCol, matrix, isDead))
                    {
                        break;
                    }
                }
                else if (matrix[armyRow, armyCol] == 'M')
                {
                    armor--;
                    matrix[armyRow, armyCol] = '-';
                    break;
                }


            }

            if (IsDead(armor, armyRow, armyCol, matrix, isDead))
            {
                Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
            }
            else
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
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

        private static bool IsDead(int armor, int armyRow, int armyCol, char[,] matrix, bool isDead)
        {
            if (armor <= 0)
            {
                matrix[armyRow, armyCol] = 'X';
                isDead = true;
            }

            return isDead;
        }

        private static bool IsOutside(ref int armor, ref int armyRow, ref int armyCol, char[,] matrix)
        {
            
            if (armyRow < 0)
            {
                armyRow = 0;
                return true;
            }
            else if (armyRow >= matrix.GetLength(0) - 1)
            {
                armyRow = matrix.GetLength(0) - 1;
                return true;
            }
            else if (armyCol < 0)
            {
                armyCol = 0;
                return true;
            }
            else if (armyCol >= matrix.GetLength(1) - 1)
            {
                armyCol = matrix.GetLength(1) - 1;
                return true;
            }

            return false;
        }
    }
}
