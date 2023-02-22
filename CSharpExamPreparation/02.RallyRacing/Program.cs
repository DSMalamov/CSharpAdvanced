
using System.Numerics;

int n = int.Parse(Console.ReadLine());
string rNumber = Console.ReadLine();

string[,] matrix = new string[n,n];

int kms = 0;
int startTrow = 0;
int startTcol = 0;
int endTrow = 0;
int endTcol = 0;
bool isFirtsT = true;
int distance = 0;
int carRow = 0;
int carCol = 0;
bool isFinished = false;

for (int i = 0;i < n; i++)
{
    string[] inputRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

	for (int y = 0; y < n; y++)
	{
		if (inputRow[y] == "T" && isFirtsT)
		{
			startTcol= y;
			startTrow= i;
			isFirtsT= false;
		}
		else if (inputRow[y] == "T")
		{
			endTcol= y;
			endTrow= i;
		}

		matrix[i, y] = inputRow[y];
	}

	
}

string command;

while ((command = Console.ReadLine()) != "End")
{
	

	if (command == "up")
	{
		carRow--;

	}
	else if (command == "down")
	{
		carRow++;
	}
	else if (command == "left")
	{
		carCol--;
	}
	else if (command == "right")
	{
		carCol++;
	}

    if (matrix[carRow, carCol] == ".")
    {
        distance += 10;
    }
    else if (matrix[carRow, carCol] == "T")
    {
        if (carRow == startTrow && carCol == startTcol)
        {
            carRow = endTrow;
            carCol = endTcol;
        }
        else
        {
            carRow = startTrow;
            carCol = startTcol;
        }
        distance += 30;
        matrix[startTrow, startTcol] = ".";
        matrix[endTrow, endTcol] = ".";
    }
    else if (matrix[carRow, carCol] == "F")
    {
        distance += 10;
        matrix[carRow, carCol] = "C";
		isFinished = true;
        break;
    }
}

if (isFinished)
{
	Console.WriteLine($"Racing car {rNumber} finished the stage!");
}
else
{
	matrix[carRow, carCol] = "C";
	Console.WriteLine($"Racing car {rNumber} DNF.");
}

Console.WriteLine($"Distance covered {distance} km.");

for (int i = 0; i < matrix.GetLongLength(0); i++)
{
	for (int y = 0; y < matrix.GetLongLength(1); y++)
	{
		Console.Write(matrix[i,y]);
	}
	Console.WriteLine();
}






