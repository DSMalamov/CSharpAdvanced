string[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
int n = int.Parse(size[0]);
int m = int.Parse(size[1]);

string[,] matrix = new string[n,m];

int currRow = -1;
int currCol = -1;
int enemy = 0;
int moves = 0;
int copyRow = -1;
int copyCol = -1;

for (int row = 0; row < n; row++)
{
	string[] rowData = Console.ReadLine()
		.Split(" ", StringSplitOptions.RemoveEmptyEntries);
		
	for (int col = 0; col < m; col++)
	{
		matrix[row, col] = rowData[col];

		if (rowData[col] == "B")
		{
			currRow= row;
			currCol= col;
			matrix[currRow, currCol] = "-";
		}
	}
}

string command;

while ((command = Console.ReadLine()) != "Finish")
{
	if (command == "up")
	{
        copyCol = currCol;
        copyRow = currRow;
		copyRow--;

	}
	else if (command == "down")
	{
        copyCol = currCol;
        copyRow = currRow;
		copyRow++;
    }
	else if (command == "left")
	{
        copyRow = currRow;
        copyCol = currCol;
		copyCol--;
	}
	else if (command == "right")
	{
        copyRow = currRow;
        copyCol = currCol;
		copyCol++;
    }

	if (copyRow < 0 || copyRow >= matrix.GetLength(0) || copyCol < 0 || copyCol >= matrix.GetLength(1))
	{
		continue;
	}
	else if (matrix[copyRow,copyCol] == "O")
	{
		continue;
	}
	else if (matrix[copyRow, copyCol] == "P")
	{
		matrix[copyRow, copyCol] = "-";
		currRow = copyRow;
		currCol = copyCol;
		enemy++;
		moves++;

    }
	else if (matrix[copyRow, copyCol] == "-")
	{
        currRow = copyRow;
        currCol = copyCol;
        moves++;
    }

	if (enemy == 3)
	{
		break;
	}
}

Console.WriteLine("Game over!");
Console.WriteLine($"Touched opponents: {enemy} Moves made: {moves}");

