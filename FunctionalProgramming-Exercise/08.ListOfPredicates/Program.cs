

int endRange = int.Parse(Console.ReadLine());

HashSet<int> dividers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToHashSet();

int[] numbers = Enumerable.Range(1, endRange).ToArray();
List<Predicate<int>> predicates = new();

foreach (var divider in dividers)
{
    predicates.Add(n => n % divider == 0);
}

foreach (var number in numbers)
{
    bool check = true;

    foreach (var predicate in predicates)
    {
        if (!predicate(number))
        {
            check = false;
            break;
        }
    }

    if (check)
    {
        Console.Write($"{number} ");
    }
}
