int input = int.Parse(Console.ReadLine());

char[,] matrix = new char[input, input];

for (int row = 0; row < matrix.GetLength(0); row++)
{
    string inputstr = Console.ReadLine();
    char[] colEl = new char[input];

    for (int i = 0; i < inputstr.Length; i++)
    {
        colEl[i] = inputstr[i];
    }
        
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = colEl[col];
    }
}

char symbol = char.Parse(Console.ReadLine());

for (int row = 0; row < matrix.GetLength(0); row++)
{
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        if (matrix[row,col] == symbol)
        {
            Console.WriteLine($"({row}, {col})");
            return;
        }
    }
}

Console.WriteLine($"{symbol} does not occur in the matrix ");
