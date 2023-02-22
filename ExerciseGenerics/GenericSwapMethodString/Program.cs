using GenericSwapMethodString;

Box<string> box = new ();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string name = Console.ReadLine();
    box.Add (name);

}

int[] indices = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

box.Swap(indices[0], indices[1]);

Console.WriteLine(box.ToString());
