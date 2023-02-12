using ListyIterator;

List<string> input = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Skip(1)
    .ToList();

ListyIterator<string> list = new (input);

string command;

while ((command = Console.ReadLine()) != "END")
{
    if (command == "Move")
    {
        Console.WriteLine(list.Move());
    }
    else if (command == "HasNext")
    {
        Console.WriteLine(list.HasNext());
    }
    else if (command == "Print")
    {
        try
        {
            list.Print();
        }
        catch (InvalidOperationException except)
        {

            Console.WriteLine(except.Message);
        }
    }
    else if (command == "PrintAll")
    {
        Console.WriteLine(String.Join(" ", list));
    }
}
