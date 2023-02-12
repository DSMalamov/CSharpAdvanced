using Stack;

CustomStack<int> stack = new();

string command;

while ((command = Console.ReadLine()) != "END")
{
    string[] cmdArg = command
        .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

    string action = cmdArg[0];

    if (action == "Push")
    {
        for (int i = 1; i < cmdArg.Length; i++)
        {
            stack.Push(int.Parse(cmdArg[i]));
        }
    }
    else if (action == "Pop")
    {
        try
        {
            stack.Pop();
        }
        catch (InvalidOperationException exept)
        {

            Console.WriteLine(exept.Message);
        }
    }
        
}

foreach (var item in stack)
{
    Console.WriteLine(item);
}
foreach(var item in stack)
{
    Console.WriteLine(item);
}
