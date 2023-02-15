using Froggy;

int[] input = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Lake stones = new(input);

Console.WriteLine(string.Join(", ", stones));
