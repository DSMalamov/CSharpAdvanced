

Action<string[], int> PrintNames = (name, number) =>
{
	foreach (var item in name)
	{
		if (item.Length <= number)
		{
			Console.WriteLine(item);
		}

	}

};

int n = int.Parse(Console.ReadLine());

string[] names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

PrintNames(names, n);