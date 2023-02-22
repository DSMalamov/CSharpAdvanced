int n = int.Parse(Console.ReadLine());

char[,] matrix = new char[n,n];

int subRow = -1;
int subCol = -1;
int health = 3;
int wins = 0;

for (int row = 0;row < n; row++)
{
	string data = Console.ReadLine();

	for (int col = 0; col < n; col++)
	{
		matrix[row, col] = data[col];

		if (data[col] == 'S')
		{
			subRow = row;
			subCol = col;
		}
	}
}

matrix[subRow, subCol] = '-';

while (health > 0 && wins < 3)
{
	string command = Console.ReadLine();

	switch (command)
	{
		case "up": subRow--; break;
		case "down": subRow++; break;
		case "left": subCol--; break;
		case "right": subCol++; break;
	}

	if (matrix[subRow,subCol] == 'C')
	{
		matrix[subRow, subCol] = '-';
		wins++;
	}
	else if (matrix[subRow, subCol] == '*')
	{
        matrix[subRow, subCol] = '-';
        health--;
    }

}

matrix[subRow, subCol] = 'S';

if (wins == 3)
{
	Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
}
else
{
	Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{subRow}, {subCol}]!");
}

Print(matrix, n);

static void Print(char[,] matrix, int n)
{
	for (int row = 0; row < n; row++)
	{
		for (int col = 0; col < n; col++)
		{
			Console.Write(matrix[row,col]);
		}
		Console.WriteLine();
	}
}