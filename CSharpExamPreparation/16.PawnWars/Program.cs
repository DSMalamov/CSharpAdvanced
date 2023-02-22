using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace _16.PawnWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 8;

            char[,] matrix = new char[n, n];
            int brow = -1;
            int bcol = -1;
            int wrow = -1;
            int wcol = -1;
            bool bqueen = false;
            bool wqueen = false;
            bool bfight = false;
            bool wfight = false;

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];

                    if (input[col] == 'b')
                    {
                        brow = row; bcol = col;
                        matrix[brow, bcol] = '-';
                    }
                    else if (input[col] == 'w')
                    {
                        wrow= row; wcol = col;
                        matrix[wrow, wcol] = '-';
                    }
                }
            }

            while (!wqueen && !wfight && !bqueen && !bfight)
            {
               
                if (wrow == brow + 1 && (bcol == wcol - 1 || bcol == wcol + 1))
                {
                    matrix[wrow, wcol] = '-';
                    wrow = brow;
                    wcol = bcol;
                    matrix[wrow, wcol] = 'w';
                    wfight= true;
                    break;
                }
                wrow--;

                if (brow == wrow - 1 && (bcol == wcol - 1 || bcol == wcol + 1))
                {
                    matrix[brow, bcol] = '-';
                    brow = wrow;
                    bcol = wcol;
                    matrix[brow, bcol] = 'b';
                    bfight= true;
                    break;
                }
                brow++;

                if (brow == n - 1)
                {
                    bqueen = true;
                    break;
                }
                else if (wrow == 0)
                {
                    wqueen = true;
                    break;
                }

            }

            if (bfight)
            {
                Console.WriteLine($"Game over! Black capture on {Coordinates(brow,bcol)}.");
            }
            else if (wfight)
            {
                Console.WriteLine($"Game over! White capture on {Coordinates(wrow, wcol)}.");
            }
            else if (bqueen)
            {
                Console.WriteLine($"Game over! Black pawn is promoted to a queen at {Coordinates(brow, bcol)}.");
            }
            else if (wqueen)
            {
                Console.WriteLine($"Game over! White pawn is promoted to a queen at {Coordinates(wrow, wcol)}.");
            }

            
        }

        public static string Coordinates(int row, int col)
        {
            string coll = string.Empty;
            int roww = Math.Abs(row - 8);
            switch (col)
            {
                case 0:
                    coll = "a";
                    break;
                case 1:
                    coll = "b";
                    break;
                case 2:
                    coll = "c";
                    break;
                case 3:
                    coll = "d";
                    break;
                case 4:
                    coll = "e";
                    break;
                case 5:
                    coll = "f";
                    break;
                case 6:
                    coll = "g";
                    break;
                case 7:
                    coll = "h";
                    break;
                
            }
            return $"{coll}{roww}";
        }
    }
}
