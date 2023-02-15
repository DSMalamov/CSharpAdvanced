
Func<HashSet<int>, int, int> minNumber = (set, n) =>
{
    foreach (var item in set)
	{
        if (item < n)
        {
            n = item;
        }
    }

    return n;
};


int minValue = int.MaxValue;

HashSet<int> numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x))
    .ToHashSet();

Console.WriteLine(minNumber(numbers, minValue));

