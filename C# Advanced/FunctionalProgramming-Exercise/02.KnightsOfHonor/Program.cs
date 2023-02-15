
Action<string[]> names = n =>
{
	foreach (var item in n)
	{
		Console.WriteLine($"Sir {item}");
	}
};

string[] inputNames = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

names(inputNames);
