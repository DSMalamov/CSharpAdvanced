int size = int.Parse(Console.ReadLine());

int[,] matrix = new int[size, size];

for (int row = 0;row < size; row++)
{
    int[] colEl = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    for (int col = 0; col < size; col++)
    {
        matrix[row, col] = colEl[col];
    }
}

int primarySum = 0;
int secondarySum = 0;

for (int row = 0; row < size; row++)
{
    primarySum += matrix[row, row];
    secondarySum += matrix[row, size - row - 1];
}

Console.WriteLine(Math.Abs(primarySum - secondarySum));
