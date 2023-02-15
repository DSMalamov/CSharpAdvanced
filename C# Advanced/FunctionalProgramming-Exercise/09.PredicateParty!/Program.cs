

using System.IO;

List<string> participants = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

string command;

while ((command = Console.ReadLine()) != "Party!")
{
    string[] cmdArg = command
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string action = cmdArg[0];
    string crytheria = cmdArg[1];
    string token = cmdArg[2];

    if (action == "Double")
    {
        List<string> list = participants.FindAll(Match(crytheria, token));

        foreach (var name in list)
        {
            int index = participants.FindIndex(p => p == name);

            participants.Insert(index, name);
        }
    }
    else if (action == "Remove")
    {
        participants.RemoveAll(Match(crytheria, token));
    }
}

if (participants.Count > 0)
{
    Console.WriteLine($"{string.Join(", ", participants)} are going to the party!");
}
else
{
    Console.WriteLine("Nobody is going to the party!");
}

static Predicate<string> Match  (string crytheria, string token)
{
    switch (crytheria)
    {
        case "StartsWith":
            return m => m.StartsWith(token);
        case "EndsWith":
            return m => m.EndsWith(token);
        case "Length":
            return m => m.Length == int.Parse(token);
        default:
            return default;
    }
}