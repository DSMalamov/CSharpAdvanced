using GenericSwapMethodInteger;

Box<int> box= new Box<int>();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    int num = int.Parse(Console.ReadLine());
    box.Add(num);
}

int[] indices = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

box.Swap(indices[0], indices[1]);

Console.WriteLine(box.ToString());
