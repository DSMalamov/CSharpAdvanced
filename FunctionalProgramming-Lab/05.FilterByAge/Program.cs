
Dictionary<string, int> people = new Dictionary<string, int>();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine()
        .Split(", ", StringSplitOptions.RemoveEmptyEntries);

    people.Add(input[0], int.Parse(input[1]));
}

Func <Dictionary<string, int>, int, bool> GetFilter( string filterType)
{
    if (filterType == "older")
    {
        return (Dictionary<string, int> (p,s) , int value) => s.Value >= value;
    }
}


