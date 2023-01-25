
Predicate<string> chacker = w => w[0] == w.ToUpper()[0];

string[] input = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Where(w => chacker(w))
    .ToArray();

foreach (var item in input)
{
    Console.WriteLine(item);
}
