
using System;
using System.Collections.Generic;
using System.Linq;

int n = int.Parse(Console.ReadLine());
string text = string.Empty;
Stack<string> changes = new();

for (int i = 0; i < n; i++)
{
    string[] cmdArg = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

    int command = int.Parse(cmdArg[0]);
    if (command == 1)
    {
        changes.Push(text);
        text += cmdArg[1];
    }
    else if (command == 2)
    {
        changes.Push(text);
        text = text.Remove(text.Length - int.Parse(cmdArg[1]));
    }
    else if (command == 3)
    {
        Console.WriteLine(text[int.Parse(cmdArg[1]) - 1]);
    }
    else if (command == 4)
    {
        string oldText = changes.Pop();
        text = oldText;
    }
}
