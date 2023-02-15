
Action<string[]> names = n =>
{
    Console.WriteLine(string.Join(Environment.NewLine, n));
};

string[] inputNames = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

names(inputNames);
