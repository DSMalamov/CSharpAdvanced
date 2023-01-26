
int[] input = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int number = int.Parse(Console.ReadLine());

Predicate<int> Match = n => n % number != 0;

Func<int[], Predicate<int>, List<int>> function = (ar, m) =>
{
    List<int> numbers = new();

    for (int i = 0; i < ar.Length; i++)
    {
        if (m(ar[i]))
        {
            numbers.Add(ar[i]);
        }
    }
    return numbers;
};

List<int> result = function(input, Match);
    result.Reverse();

Console.WriteLine(string.Join(" ", result));
