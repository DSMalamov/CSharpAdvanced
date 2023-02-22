
Queue<int> textiles = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
Stack<int> medicaments = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

List<Healing> list = new();
list.Add(new Healing("Patch", 30));
list.Add(new Healing("Bandage", 40));
list.Add(new Healing("MedKit", 100));

bool isFount = false;
int leftover = 0;

while (textiles.Count > 0 && medicaments.Count>0)
{
    int currTextil = textiles.Dequeue();
    int currMed = medicaments.Pop();
    int sum = currTextil+currMed;

    foreach (var item in list)
    {
        if (item.Value == sum)
        {
            item.Count++;
            isFount= true;
            
        }
    }

    if (!isFount)
    {
        if (sum > 100)
        {
            var item = list.First(n => n.Name == "MedKit");
            item.Count++;
            leftover = sum - 100;

            if (medicaments.Count > 0)
            {
                int newItem = medicaments.Pop();
                medicaments.Push(newItem + leftover);
            }
            
        }
        else
        {
             currMed += 10;
             medicaments.Push(currMed);
        }

    }

    isFount = false;

}

if (medicaments.Count == 0 && textiles.Count == 0)
{
    Console.WriteLine("Textiles and medicaments are both empty.");
}
else if (medicaments.Count > 0)
{
    Console.WriteLine("Textiles are empty.");
}
else if (textiles.Count > 0)
{
    Console.WriteLine("Medicaments are empty.");
}

foreach (var item in list.Where(c => c.Count > 0).OrderByDescending(c => c.Count).ThenBy(n => n.Name))
{
    Console.WriteLine($"{item.Name} - {item.Count}");
}

if (medicaments.Count > 0)
{
    Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
}
else if (textiles.Count > 0)
{
    Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");
}

public class Healing
{
    public Healing(string name, int value)
    {
        Name = name;
        Value = value;
        Count = 0;
    }

    public string Name { get; set; }
    public int Value { get; set; }
    public int Count { get; set; }
}