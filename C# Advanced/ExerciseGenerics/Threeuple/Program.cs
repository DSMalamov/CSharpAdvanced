using Threeuple;

string[] info1 = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[] info2 = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[] info3 = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

CustomThreeuple<string, string, string> nameAdressCity = 
    new($"{info1[0]} {info1[1]}", info1[2], String.Join(" ", info1[3..]));

CustomThreeuple<string, int, bool> nameLitesDrunk = new(info2[0], int.Parse(info2[1]), info2[2] == "drunk");

CustomThreeuple<string, double, string> nameBank = new(info3[0], double.Parse(info3[1]), info3[2]);

Console.WriteLine(nameAdressCity);
Console.WriteLine(nameLitesDrunk);
Console.WriteLine(nameBank);
