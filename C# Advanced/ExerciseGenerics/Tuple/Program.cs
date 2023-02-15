using Tuple;

string[] nameArg = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[] beerArg = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[] numArg = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

CustomTuple<string, string> nameAdress = new($"{nameArg[0]} {nameArg[1]}", string.Join(" ", nameArg[2..]));
CustomTuple<string, int> nameLiters = new(beerArg[0], int.Parse(beerArg[1]));
CustomTuple<int, double> numbers = new(int.Parse(numArg[0]), double.Parse(numArg[1]));

Console.WriteLine(nameAdress);
Console.WriteLine(nameLiters);
Console.WriteLine(numbers);
