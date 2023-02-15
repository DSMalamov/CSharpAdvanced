using GenericBoxOfInteger;

Box<int> box = new();
int n = int.Parse(Console.ReadLine());

for (int i = 0;i < n; i++)
{
    int number =int.Parse(Console.ReadLine());

    box.Add(number);
}

Console.WriteLine(box.ToString());

