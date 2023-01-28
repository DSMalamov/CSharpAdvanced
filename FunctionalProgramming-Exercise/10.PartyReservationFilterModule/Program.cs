

List<string> participants = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

List<string> filters = new();

string command;

while ((command = Console.ReadLine()) != "Print")
{
    string[] cmdArg = command
        .Split(";", StringSplitOptions.RemoveEmptyEntries);

    string type = cmdArg[1];
    string token = cmdArg[2];

    if (cmdArg[0] == "Add filter")
    {
        filters.Add($"{type};{token}");
    }
    else if (cmdArg[0] == "Remove filter")
    {
        if (filters.Contains($"{type};{token}"))
        {
            filters.Remove($"{type};{token}");
        }
    }
}



foreach (var filter in filters)
{
    string[] currFilter = filter
            .Split(";", StringSplitOptions.RemoveEmptyEntries);

    string type = currFilter[0];
    string token = currFilter[1];

    participants.RemoveAll(Filter(type, token));
}

Console.WriteLine(string.Join(" ", participants));


 static Predicate <string> Filter (string type,string token)
{

    if (type == "Starts with")
    {
        return m => m.StartsWith(token);
    }
    else if (type == "Ends with")
    {
        return m => m.EndsWith(token);
    }
    else if (type == "Length")
    {
        return m => m.Length == int.Parse(token);
    }
    else if (type == "Contains")
    {
        return m => m.Contains(token);
    }

    return default;
}
