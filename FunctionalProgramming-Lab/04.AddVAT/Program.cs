

string input = Console.ReadLine();
Func<string, double> parser = n => double.Parse(n);
Func<double, double> multiplyer = n => n * 1.2; 

double[] numbers = input
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(parser)
    .Select(multiplyer)
    .ToArray();

foreach (var number in numbers)
{
    Console.WriteLine($"{number:f2}");
}
