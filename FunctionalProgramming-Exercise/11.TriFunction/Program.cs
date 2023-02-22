


Func<string, int, bool> function = (n, h) => n.Sum(ch => ch) >= h;


Func<string[], Func<string, int, bool>, int, string> Logic = (names, value, sum) => names
.FirstOrDefault(name => value(name, sum));

int n = int.Parse(Console.ReadLine());

string[] names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Console.WriteLine(Logic(names, function, n));
