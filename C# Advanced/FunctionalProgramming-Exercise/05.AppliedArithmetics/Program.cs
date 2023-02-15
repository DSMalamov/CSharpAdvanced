
int[] input = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

string command;

Action<int[]> Print = array =>
{
    Console.WriteLine(String.Join(" ", array));
};

Func<int[], char, int[]> function = (ar, n) =>
{
    for (int i = 0; i < ar.Length; i++)
    {
        if (n == '*')
        {
            ar[i] *= 2;
        }
        else if (n == '+')
        {
            ar[i]++;
        }
        else if (n == '-')
        {
            ar[i]--;
        }
    }

    return ar;

};

while ((command = Console.ReadLine()) != "end")
{
    if (command == "print")
    {
        Print(input);
    }
    else
    {
        char a;

        switch (command)
        {
            case "add": a = '+'; function(input, a); break;
            case "multiply": a = '*'; function(input, a); break;
            case "subtract": a = '-'; function(input, a); break;
                
        }
    }
}