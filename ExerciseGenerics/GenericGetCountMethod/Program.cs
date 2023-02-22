using GenericGetCountMethod;

Box<string> box = new();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    var item = Console.ReadLine();

    box.Add(item);
}

string itemToCompare = Console.ReadLine();

Console.WriteLine(box.Count(itemToCompare));
