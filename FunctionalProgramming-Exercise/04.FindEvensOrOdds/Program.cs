
using System.Reflection.Metadata.Ecma335;

Func<int, int, List<int>> functinon = (start, end) =>
{
    List<int> result = new List<int>();

    for (int i = start; i <= end; i++)
    {
        result.Add(i);
    }
    return result;
};
Predicate<int> match;

int[] range = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

string command = Console.ReadLine();

List<int> numbers = functinon(range[0], range[1]);


if (command == "odd")
{
    match = number => number % 2 != 0;
}
else
{
    match = number => number % 2 == 0;
}


foreach (var item in numbers)
{
    if (match(item))
    {
        Console.Write($"{item} ");
    }
}
